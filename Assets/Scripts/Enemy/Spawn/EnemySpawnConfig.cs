using UnityEngine;

namespace Enemy.Spawn
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "Configs/EnemySpawnConfig", order = 0)]
    public class EnemySpawnConfig : ScriptableObject
    {
        private static EnemySpawnConfig _instance;

        public static EnemySpawnConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<EnemySpawnConfig>("EnemySpawnConfig");
                }

                return _instance;
            }
        }

        [Header("Spawn zone")]
        [SerializeField] private float spawnZoneWidth;
        [SerializeField] private float spawnZoneLength;
        [Header("Enemies placement")]
        [SerializeField] private int enemiesCount;
        [SerializeField] private float minDistanceBetween;
        
        public float SpawnZoneWidth => spawnZoneWidth;
        public float SpawnZoneLength => spawnZoneLength;
        public int EnemiesCount => enemiesCount;
        public float MinDistanceBetween => minDistanceBetween;
    }
}