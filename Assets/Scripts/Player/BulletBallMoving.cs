using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class BulletBallMoving : MonoBehaviour, IBulletBallMoving
    {
        [SerializeField] private Transform targetTransf;
        [SerializeField] private Rigidbody usedRigidbody;
        private Vector3 _startPosition;
        private CancellationToken _token;

        private void Start()
        {
            _startPosition = transform.position;
        }

        public void Shoot(float forceFactor)
        {
            usedRigidbody.AddForce(-targetTransf.position * forceFactor);
        }

        public void Stop()
        {
            usedRigidbody.velocity = Vector3.zero;
            usedRigidbody.angularVelocity = Vector3.zero;
        }

        public void ResetPosition()
        {
            transform.position = _startPosition;
        }
    }
}