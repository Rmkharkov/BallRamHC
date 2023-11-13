using UnityEngine.Events;

namespace Enemy
{
    public interface IEnemyGetHit
    {
        UnityEvent HitByAnotherEnemyEvent { get; }
        UnityEvent HitByPlayerEvent { get; }
        void Init(IEnemyView enemyView);
    }
}