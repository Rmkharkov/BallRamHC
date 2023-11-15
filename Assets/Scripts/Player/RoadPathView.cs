using System;
using UnityEngine;

namespace Player
{
    public class RoadPathView : MonoBehaviour, IRoadPathView
    {
        private Vector3 _startScale;

        private void Start()
        {
            _startScale = transform.localScale;
        }

        public void DecreaseWidth(float percentFromStartSize)
        {
            var decreaseValue = _startScale.x * percentFromStartSize;
            var setScale = transform.localScale.x - decreaseValue;
            transform.localScale = new Vector3(setScale, _startScale.y, _startScale.z);
        }

        public void ResetSize()
        {
            transform.localScale = _startScale;
        }
    }
}