using Utils.ResourceManager.Factory.Config;

namespace Utils.ResourceManager.Factory
{
    interface IConfigFactory
    {
        UnitConfig GetUnitConfig(string configName);
        BuildingConfig GetBuildingConfig(string configName);
    }
}