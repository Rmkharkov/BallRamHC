using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyMaterialsConfig", menuName = "Configs/EnemyMaterialsConfig", order = 0)]
    public class EnemyMaterialsConfig : ScriptableObject
    {
        private static EnemyMaterialsConfig _instance;

        public static EnemyMaterialsConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<EnemyMaterialsConfig>("EnemyMaterialsConfig");
                }

                return _instance;
            }
        }

        [SerializeField] private List<EnemyStateMaterial> materials = new List<EnemyStateMaterial>();

        public Material GetStateMaterial(EEnemyState state)
        {
            return materials.Find(c => c.enemyState == state).material;
        }
    }
}