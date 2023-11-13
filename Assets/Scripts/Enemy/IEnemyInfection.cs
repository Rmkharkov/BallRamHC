using UnityEngine.Events;

namespace Enemy
{
    public interface IEnemyInfection
    {
        UnityEvent InfectedEvent { get; }
        void Init(IEnemyView enemyView);
        void TransferInfection();
        void InfectMe();
    }
}