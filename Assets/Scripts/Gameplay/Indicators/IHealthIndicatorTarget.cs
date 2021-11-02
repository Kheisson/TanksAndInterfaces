namespace Gameplay.Indicators
{
    public interface IHealthIndicatorTarget : IUiIndicatorTarget
    {
        int Health { get; }
    }
}