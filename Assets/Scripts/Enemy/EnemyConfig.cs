using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        private static EnemyConfig _instance;

        public static EnemyConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<EnemyConfig>("EnemyConfig");
                }

                return _instance;
            }
        }

        [SerializeField] private float infectTransferDelay;
        [SerializeField] private float infectToDeathDelay;
        public float InfectTransferDelay => infectTransferDelay;
        public float InfectToDeathDelay => infectToDeathDelay;
    }
}