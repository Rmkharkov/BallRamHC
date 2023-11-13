using UnityEngine.Events;

namespace Game
{
    public interface IMatchRegulator
    {
        UnityEvent ResetMatch { get; }
        UnityEvent LostMatch { get; }
        UnityEvent WonMatch { get; }
    }
}