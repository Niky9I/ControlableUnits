using System.Collections.Generic;
using UnityEngine;
using Utils.ResourceManager.Factory.Config;

namespace Utils.ResourceManager
{
    public class PrefabLoader
    {
        private Dictionary<string, GameObject> _prefabCache; //<configName, prefab>

        public PrefabLoader()
        {
            _prefabCache = new Dictionary<string, GameObject>();
        }

        public void ClearCache()
        {
            if (_prefabCache.Count > 0)
                _prefabCache.Clear();
        }
        
        public GameObject LoadPrefab<T>(string prefabPath, T configObject)
        {
            if (_prefabCache.TryGetValue(prefabPath, out GameObject prefab))
            {
                return prefab;
            }

            prefab = Resources.Load<GameObject>(prefabPath);

            if (prefab != null)
            {
                FillPrefabWithData(prefab, configObject);
                _prefabCache.Add(prefabPath, prefab);
            }
            else
            {
                Debug.LogError($"Не удалось найти префаб {prefabPath} в ресурсах проекта");
            }

            return prefab;
        }
        
        /// <summary>
        /// Наполнение префаба данными
        /// </summary>
        /// <param name="prefab">Объект префаба</param>
        /// <param name="configObject">Объект конфигурационного файла</param>
        /// <typeparam name="T">Тип конфигурационного файла</typeparam>
        private void FillPrefabWithData<T>(GameObject prefab, T configObject)
        {
            var hpComponent = prefab.GetComponent<HPComponent>();
            var speedComponent = prefab.GetComponent<SpeedComponent>();
            var attackComponent = prefab.GetComponent<AttackComponent>();
            var costComponent = prefab.GetComponent<CostComponent>();
            var visionComponent = prefab.GetComponent<VisionComponent>();
            
            if (typeof(T) == typeof(IBuildingConfig))
            {
                IBuildingConfig buildingConfig = (IBuildingConfig) configObject;
                //TODO заполнить для зданий, когда появятся необходимые компоненты
            }

            if (typeof(T) == typeof(IUnitConfig))
            {
                IUnitConfig unitConfig = (IUnitConfig) configObject;
                
                if (hpComponent != null) hpComponent.MaxHP = (int) unitConfig.Hp;
                if (speedComponent != null) speedComponent.MaxSpeed = unitConfig.Speed;
                if (attackComponent != null)
                {
                    attackComponent.MinDamage = (int) unitConfig.MinAttack;
                    attackComponent.MaxDamage = (int) unitConfig.MaxAttack;
                    attackComponent.AttackDelay = (int) unitConfig.AttackSpeed;
                }
                if (costComponent != null) costComponent.Gold = (int) unitConfig.Cost;
                if (visionComponent != null) visionComponent.AttackRange = unitConfig.MaxDistance;
            }
        }
    }
}