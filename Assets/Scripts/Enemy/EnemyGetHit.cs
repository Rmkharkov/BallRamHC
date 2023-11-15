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
        public UnityEvent HitByPlayerEvent { get; } = new UnityEvent();

        public void Init(IEnemyView enemyView)
        {
            HitByPlayerEvent.RemoveAllListeners();
            _enemyView = enemyView;
        }
        
        public void HitByPlayer()
        {
            HitByPlayerEvent.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player) && !_enemyView.IsSick)
            {
                HitByPlayerEvent.Invoke();
            }  
        }
    }
}