using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyInfection : MonoBehaviour, IEnemyInfection
    {
        [SerializeField] private Collider infectionCollider;
        
        private IEnemyView _enemyView;
        
        public UnityEvent InfectedEvent { get; } = new UnityEvent();

        public async void Init(IEnemyView enemyView)
        {
            // InfectedEvent.RemoveAllListeners();
            
            _enemyView = enemyView;
            if (infectionCollider != null)
            {
                infectionCollider.enabled = false;
            }

            await Task.Yield();
            
            _enemyView.EnemyGetHit.HitByPlayerEvent.AddListener(InfectMe);
            _enemyView.EnemyGetHit.HitByAnotherEnemyEvent.AddListener(InfectMe);
        }

        public void TransferInfection()
        {
            if (infectionCollider != null)
            {
                infectionCollider.enabled = true;
            }
        }

        public void InfectMe()
        {
            InfectedEvent.Invoke();
        }
    }
}