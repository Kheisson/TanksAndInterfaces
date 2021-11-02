namespace Gameplay.Indicators
{
    public interface ICooldownIndicatorTarget : IUiIndicatorTarget
    {
        float InverseCooldownProgress { get; }

        bool IsInCooldown { get; }
    }
}