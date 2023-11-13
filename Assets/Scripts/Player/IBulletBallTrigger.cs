using UnityEngine.Events;

namespace Player
{
    public interface IBulletBallTrigger
    {
        UnityEvent HitEnemy { get; }
    }
}