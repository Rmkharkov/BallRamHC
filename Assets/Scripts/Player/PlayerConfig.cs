using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        private static PlayerConfig _instance;

        public static PlayerConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<PlayerConfig>("PlayerConfig");
                }

                return _instance;
            }
        }

        [Header("Growth")]
        [SerializeField] private float minimumSourceScale;
        [SerializeField] private float decreaseSourceSpeed;
        [SerializeField] private float growBulletSpeed;
        [SerializeField] private float scaleTimeStamp;
        [Header("Moving")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float movingTimeStamp;
        public float MinimumSourceScale => minimumSourceScale;
        public float DecreaseSourceSpeed => decreaseSourceSpeed;
        public float GrowBulletSpeed => growBulletSpeed;
        public float ScaleTimeStamp => scaleTimeStamp;
        public float MoveSpeed => moveSpeed;
        public float MovingTimeStamp => movingTimeStamp;

    }
}