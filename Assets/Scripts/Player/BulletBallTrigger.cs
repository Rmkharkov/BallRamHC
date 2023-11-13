using System;
using Enemy;
using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BulletBallTrigger : MonoBehaviour, IBulletBallTrigger
    {
        public UnityEvent HitEnemyEvent { get; } = new UnityEvent();
        public UnityEvent ArrivedToGarage { get; } = new UnityEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                HitEnemyEvent.Invoke();
                var enemyTrigger = other.GetComponent<IEnemyInfection>();
                // enemyTrigger?.InfectMe();
            }
            else if (other.CompareTag(Tags.BallStopTrigger))
            {
                ArrivedToGarage.Invoke();
            }
        }
    }
}