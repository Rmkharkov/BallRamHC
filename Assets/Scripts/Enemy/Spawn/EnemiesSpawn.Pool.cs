using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Spawn
{
    public partial class EnemiesSpawn
    {
        [SerializeField] private Transform poolParent;
        [SerializeField] private Transform enemiesParent;
        
        private readonly List<EnemyView> _enemiesInPool = new List<EnemyView>();
        private readonly List<EnemyView> _enemiesOnBoard = new List<EnemyView>();
        
        private EnemyView GetEnemyFromPoolTo(Vector3 localPosition)
        {
            if (_enemiesInPool.Count > 0)
            {
                var enemy = _enemiesInPool[0];
                _enemiesInPool.Remove(enemy);
                enemy.transform.SetParent(enemiesParent);
                enemy.transform.localPosition = localPosition;
                return enemy;
            }

            return null;
        }

        public void HideEnemy(EnemyView enemy)
        {
            _enemiesInPool.Add(enemy);
            enemy.transform.SetParent(poolParent);
            _enemiesOnBoard.Remove(enemy);
        }
    }
}