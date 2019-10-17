namespace Utils.ResourceManager.Factory.Config
{
    public interface IBuildingConfig
    {
        float Strength { get; }
        float ResProdInterval { get; }      //интервал производства ресурсов
        float ResProdAmount { get; }        //количество производимых ресурсов
        float Cost { get; }
        string PrefabPath { get; }
    }
}