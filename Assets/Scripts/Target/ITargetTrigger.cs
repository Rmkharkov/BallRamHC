using UnityEngine.Events;

namespace Target
{
    public interface ITargetTrigger
    {
        UnityEvent BallArrived { get; }
    }
}