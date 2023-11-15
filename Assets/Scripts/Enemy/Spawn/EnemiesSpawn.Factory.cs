using UnityEngine;

namespace Enemy.Spawn
{
    public partial class EnemiesSpawn
    {
        private EnemyView CreateNewEnemy(Vector3 localPosition)
        {
            var enemy = Instantiate(UsedEnemyConfig.EnemyPrefab, enemiesParent);
            enemy.transform.localPosition = localPosition;

            return enemy;
        }
    }
}