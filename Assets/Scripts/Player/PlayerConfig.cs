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
        [SerializeField] private float growBulletColliderFactor;
        [Header("Moving")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float afterEnemyHitDelay;
        public float MinimumSourceScale => minimumSourceScale;
        public float DecreaseSourceSpeed => decreaseSourceSpeed;
        public float GrowBulletSpeed => growBulletSpeed;
        public float ScaleTimeStamp => scaleTimeStamp;
        public float MoveSpeed => moveSpeed;
        public float GrowBulletColliderFactor => growBulletColliderFactor;
        public float AfterEnemyHitDelay => afterEnemyHitDelay;

    }
}