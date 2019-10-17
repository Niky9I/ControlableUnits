namespace Utils.ResourceManager.Factory.Config
{
    public interface IUnitConfig
    {
        float Hp { get; }
        float MinAttack { get; }
        float MaxAttack { get; }
        float AttackSpeed { get; }
        float MinDistance { get; }
        float MaxDistance { get; }
        float Defense { get; }
        float BuildTime { get; }
        float Speed { get; }
        float Cost { get; }
        string PrefabPath { get; }
    }
}