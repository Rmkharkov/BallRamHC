using UnityEngine;

namespace Player
{
    public class BallSourceView : MonoBehaviour, IBallSourceView
    {
        [SerializeField] private Transform transformToScale;
        private float _startScale;

        private void Start()
        {
            _startScale = transformToScale.localScale.x;
        }


        public bool Decrease(float percent, float minimumScale)
        {
            var localScale = transformToScale.localScale;
            
            var currentScale = localScale;
            var scaleStep = _startScale * percent;
            
            localScale = new Vector3(currentScale.x - scaleStep, currentScale.y - scaleStep,
                currentScale.z - scaleStep);
            
            transformToScale.localScale = localScale;

            return localScale.x > minimumScale;
        }

        public void ResetSize()
        {
            transformToScale.localScale = new Vector3(_startScale, _startScale,_startScale);
        }
    }
}