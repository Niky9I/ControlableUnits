using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using Utils.ResourceManager.Factory.Config;

namespace Utils.ResourceManager.Factory
{
    class ConfigFactory : IConfigFactory
    {
        private string _configPath; //путь до папки с конфигурациями относительно Resources
        private Dictionary<string, string> _configs; //<configName, configText>

        private Dictionary<string, UnitConfig> _unitConfigCache;
        private Dictionary<string, BuildingConfig> _buildingConfigCache;

        public ConfigFactory(string configPath)
        {
            _configs = new Dictionary<string, string>();
            _unitConfigCache = new Dictionary<string, UnitConfig>();
            _buildingConfigCache = new Dictionary<string, BuildingConfig>();
            
            _configPath = configPath;
            Initialize(_configPath);
        }

        /// <summary>
        /// Загружает (переподгружает) коллекцию с конфигурационными файлами
        /// </summary>
        /// <param name="configPath">Путь до папки с конфигурационными файлами</param>
        private void Initialize(string configPath)
        {
            if (_configs.Count != 0) _configs.Clear();

            foreach (TextAsset config in Resources.LoadAll(configPath, typeof(TextAsset)))
            {
                if (!_configs.ContainsKey(config.name))
                {
                    _configs.Add(config.name, config.text);
                }
                else
                    Debug.LogError($"Обнаружен дубликат для конфигурационного файла {config.name}");
            }
        }

        private T FillObjectWithData<T>(string configName) where T : class
        {
            if (_configs.TryGetValue(configName, out string configText))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(configText))
                {
                    return serializer.Deserialize(stringReader) as T;
                }
            }

            return default;
        }
        
        public BuildingConfig GetBuildingConfig(string configName)
        {
            if (_buildingConfigCache.TryGetValue(configName, out BuildingConfig resultConfig))
            {
                return resultConfig;
            }
            
            var config = FillObjectWithData<BuildingConfig>(configName);
            _buildingConfigCache.Add(configName, config);
            return config;
        }
        
        public UnitConfig GetUnitConfig(string configName)
        {
            if (_unitConfigCache.TryGetValue(configName, out UnitConfig resultConfig))
            {
                return resultConfig;
            }
            
            var config = FillObjectWithData<UnitConfig>(configName);
            _unitConfigCache.Add(configName, config);
            return config;
        }
    }
}