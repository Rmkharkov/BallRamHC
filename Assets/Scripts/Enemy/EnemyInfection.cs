using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyInfection : MonoBehaviour, IEnemyInfection
    {
        private IEnemyView _enemyView;
        
        public UnityEvent InfectedEvent { get; } = new UnityEvent();

        public async void Init(IEnemyView enemyView)
        {
            InfectedEvent.RemoveAllListeners();
            
            _enemyView = enemyView;

            await Task.Yield();
            
            _enemyView.EnemyGetHit.HitByPlayerEvent.AddListener(InfectedByPlayer);
        }

        private void InfectedByPlayer()
        {
            InfectedEvent.Invoke();
        }
    }
}