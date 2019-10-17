using ProjectOne.Enums;

namespace Utils.ResourceManager.Factory.Config
{
    public static class ConfigName
    {
        public const string SWORDSMAN = "swordsman";
        public const string ARCHER = "archer";
        public const string CASTLE = "castle";

        public static string EnumToConfigName(UnitType unitType)
        {
            switch (unitType)
            {
                case UnitType.Swordsman:
                    return SWORDSMAN;
                case UnitType.Archer:
                    return ARCHER;
            }

            return string.Empty;
        }

        public static string EnumToConfigName(BuildingType buildingType)
        {
            switch (buildingType)
            {
                case BuildingType.Castle:
                    return CASTLE;
            }

            return string.Empty;
        }
    }
}