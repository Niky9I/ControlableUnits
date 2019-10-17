using ProjectOne.Enums;
using UnityEngine;
using Utils.ResourceManager.Factory.Config;

namespace Utils.ResourceManager
{
    public class Example : MonoBehaviour
    {
        private ResourceManager _resourceManager;

        private void Start()
        {
            _resourceManager = ResourceManager.Manager;

            //получение конфигов
            Debug.Log(_resourceManager.GetConfig<IBuildingConfig>(ConfigName.CASTLE));
            Debug.Log(_resourceManager.GetConfig<IUnitConfig>(ConfigName.SWORDSMAN));
            Debug.Log(_resourceManager.GetConfig<IUnitConfig>(ConfigName.ARCHER));

            //получение префабов
            Instantiate(_resourceManager.GetPrefab(BuildingType.Castle), new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(_resourceManager.GetPrefab(UnitType.Swordsman), new Vector3(3, 0, 0), Quaternion.identity);
            Instantiate(_resourceManager.GetPrefab(UnitType.Archer), new Vector3(3, 0.5f, -3), Quaternion.identity);
        }
    }
}