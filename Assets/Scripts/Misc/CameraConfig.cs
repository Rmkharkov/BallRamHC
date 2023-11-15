using UnityEngine;

namespace Misc
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        private static CameraConfig _instance;

        public static CameraConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<CameraConfig>("CameraConfig");
                }

                return _instance;
            }
        }

        [SerializeField] private Vector2 targetResolution;
        [SerializeField] private Vector2 minResolution;
        [SerializeField] private Vector2 maxResolution;
        [SerializeField] private float minimumFiledValue;
        [SerializeField] private float maximumFiledValue;

        public float TargetResolution => targetResolution.x / targetResolution.y;
        public float MinResolution => minResolution.x / minResolution.y;
        public float MaxResolution => maxResolution.x / maxResolution.y;
        public float MinimumFieldValue => minimumFiledValue;
        public float MaximumFiledValue => maximumFiledValue;
    }
}