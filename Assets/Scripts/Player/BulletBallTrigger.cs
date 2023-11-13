using System;
using Enemy;
using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BulletBallTrigger : MonoBehaviour, IBulletBallTrigger
    {
        public UnityEvent HitEnemy { get; } = new UnityEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                HitEnemy.Invoke();
                var enemyTrigger = other.GetComponent<IEnemyInfection>();
                enemyTrigger?.InfectMe();
            }
        }
    }
}