using ProjectOne.Enums;
using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using Utils.ResourceManager.Enum;
using Utils.ResourceManager.Factory;
using Utils.ResourceManager.Factory.Config;

namespace Utils.ResourceManager
{
    public class ResourceManager
    {
        private const string RESOURCE_PATH_FILE = "resource_path";
        private const string RESOURCE_EL = "resource";
        private const string TYPE_ATTR = "type";

        private static ResourceManager _resourceManager;

        private IConfigFactory _configFactory;
        private PrefabLoader _prefabLoader;
        private Dictionary<string, string> _rsPath;

        public static ResourceManager Manager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager();
                    _resourceManager.Initialize();
                }

                return _resourceManager;
            }
        }

        private ResourceManager()
        {
            _rsPath = new Dictionary<string, string>();
            _prefabLoader = new PrefabLoader();
        }

        /// <summary>
        /// Инициализация ресурсного менеджера (также этот метод заново переподгружает конфигурации при необходимости)
        /// </summary>
        public void Initialize()
        {
            try
            {
                LoadResourcePath();
                LoadConfig();
            }
            catch (ApplicationException e)
            {
                Debug.LogError(e.Message);
            }
        }

        /// <summary>
        /// Загружает пути до ресурсов
        /// </summary>
        private void LoadResourcePath()
        {
            if (_rsPath.Count != 0) _rsPath.Clear();

            TextAsset rsPath = Resources.Load(RESOURCE_PATH_FILE) as TextAsset;
            if (rsPath == null)
                throw new ApplicationException($"Не удалось найти файл с путями до конифгурационных файлов: {RESOURCE_PATH_FILE}");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(rsPath.text);

            foreach (XmlElement xmlElement in xmlDocument.DocumentElement.GetElementsByTagName(RESOURCE_EL))
            {
                if (_rsPath.ContainsKey(xmlElement.GetAttribute(TYPE_ATTR))) _rsPath[xmlElement.GetAttribute(TYPE_ATTR)] = xmlElement.InnerText;
                else
                    _rsPath.Add(xmlElement.GetAttribute(TYPE_ATTR), xmlElement.InnerText);
            }
        }

        /// <summary>
        /// Загружает все конфигурации в коллекцию
        /// </summary>
        private void LoadConfig()
        {
            if (!_rsPath.ContainsKey(ResourceType.Config.ToString()))
                throw new ApplicationException($"В файле {RESOURCE_PATH_FILE} отсутствуют настройки для файлов конфигураций {ResourceType.Config.ToString()}");

            _configFactory = new ConfigFactory(_rsPath[ResourceType.Config.ToString()]);
        }

        /// <summary>
        /// Получение настроек из конфигурационного файла
        /// </summary>
        /// <typeparam name="T">Тип, который необходимо получить на выходе</typeparam>
        /// <param name="configName">Название конфигурационного файла</param>
        /// <returns>Объект с загруженными настройками указанного типа T</returns>
        public T GetConfig<T>(string configName) where T : class
        {
            if (typeof(T) == typeof(IUnitConfig))
                return _configFactory.GetUnitConfig(configName) as T;
            if (typeof(T) == typeof(IBuildingConfig))
                return _configFactory.GetBuildingConfig(configName) as T;

            return default;
        }

        public GameObject GetPrefab(UnitType unitType)
        {
            string configName = ConfigName.EnumToConfigName(unitType);

            if (!string.IsNullOrEmpty(configName))
            {
                if (TryGetConfigPath(ResourceType.Prefab, out string rsPath))
                {
                    IUnitConfig unitConfig = _configFactory.GetUnitConfig(configName);
                    return _prefabLoader.LoadPrefab($"{rsPath}{unitConfig.PrefabPath}", unitConfig);
                }
            }

            return null;
        }

        public GameObject GetPrefab(BuildingType buildingType)
        {
            string configName = ConfigName.EnumToConfigName(buildingType);

            if (!string.IsNullOrEmpty(configName))
            {
                if (TryGetConfigPath(ResourceType.Prefab, out string rsPath))
                {
                    IBuildingConfig buildingConfig = _configFactory.GetBuildingConfig(configName);
                    return _prefabLoader.LoadPrefab($"{rsPath}{buildingConfig.PrefabPath}", buildingConfig);
                }
            }

            return null;
        }

        private bool TryGetConfigPath(ResourceType resourceType, out string result)
        {
            if (_rsPath.TryGetValue(resourceType.ToString(), out string rsPath))
            {
                result = rsPath;
                return true;
            }

            result = string.Empty;
            
            Debug.LogError($"В файле {RESOURCE_PATH_FILE} отсутствуют настройки для файлов конфигураций {ResourceType.Prefab.ToString()}");
            return false;
        }
    }
}