using System;
using System.Threading.Tasks;
using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyGetHit : MonoBehaviour, IEnemyGetHit
    {
        private IEnemyView _enemyView;
        public UnityEvent HitByAnotherEnemyEvent { get; } = new UnityEvent();
        public UnityEvent HitByPlayerEvent { get; } = new UnityEvent();

        public void Init(IEnemyView enemyView)
        {
            HitByAnotherEnemyEvent.RemoveAllListeners();
            HitByPlayerEvent.RemoveAllListeners();
            
            _enemyView = enemyView;
        }
        
        public void HitByPlayer()
        {
            HitByPlayerEvent.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                HitByAnotherEnemyEvent.Invoke();
            } 
            else if (other.CompareTag(Tags.Player))
            {
                HitByPlayerEvent.Invoke();
            }  
        }
    }
}