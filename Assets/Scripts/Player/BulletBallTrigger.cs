using System;
using Enemy;
using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BulletBallTrigger : MonoBehaviour, IBulletBallTrigger
    {
        [SerializeField] private SphereCollider hitCollider;
        public UnityEvent HitEnemyEvent { get; } = new UnityEvent();
        public UnityEvent ArrivedToGarage { get; } = new UnityEvent();
        private float _startScale;

        private void Start()
        {
            _startScale = hitCollider.radius;
            hitCollider.enabled = false;
        }

        public void Growth(float percent)
        {
            var scaleStep = _startScale * percent;
            hitCollider.radius += scaleStep;
        }

        public void ResetSize()
        {
            hitCollider.radius = _startScale;
            hitCollider.enabled = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Tags.Enemy))
            {
                HitEnemyEvent.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                hitCollider.enabled = true;
                HitEnemyEvent.Invoke();
            }
            else if (other.CompareTag(Tags.BallStopTrigger))
            {
                ArrivedToGarage.Invoke();
            }
        }
    }
}