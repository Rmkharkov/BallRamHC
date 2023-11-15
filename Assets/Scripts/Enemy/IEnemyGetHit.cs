using UnityEngine.Events;

namespace Enemy
{
    public interface IEnemyGetHit
    {
        UnityEvent HitByPlayerEvent { get; }
        void Init(IEnemyView enemyView);
    }
}