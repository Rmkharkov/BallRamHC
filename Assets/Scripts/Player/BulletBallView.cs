using System;
using UI;
using UnityEngine;

namespace Player
{
    public class BulletBallView : MonoBehaviour, IBulletBallView
    {
        [SerializeField] private Transform transformToScale;
        private float _startScale;

        private void Start()
        {
            _startScale = transformToScale.localScale.x;
        }

        public void Growth(float percent)
        {
            var currentScale = transformToScale.localScale;
            var scaleStep = _startScale * percent;
            transformToScale.localScale = new Vector3(currentScale.x + scaleStep, currentScale.y + scaleStep,
                currentScale.z + scaleStep);
        }

        public void ResetSize()
        {
            transformToScale.localScale = new Vector3(_startScale, _startScale,_startScale);
        }
    }
}