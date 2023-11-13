using System;
using Misc;
using UnityEngine;
using UnityEngine.Events;

namespace Target
{
    public class TargetTrigger : MonoBehaviour, ITargetTrigger
    {
        public UnityEvent BallArrived { get; } = new UnityEvent();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                BallArrived.Invoke();
            }
        }
    }
}