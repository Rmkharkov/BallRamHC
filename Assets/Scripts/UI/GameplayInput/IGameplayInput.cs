using UnityEngine.Events;

namespace UI.GameplayInput
{
    public interface IGameplayInput
    {
        UnityEvent StartGrowth { get; }
        UnityEvent EndGrowth { get; }
    }
}