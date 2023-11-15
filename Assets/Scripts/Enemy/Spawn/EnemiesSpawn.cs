using System;
using System.Linq;
using Game;
using UnityEngine;

namespace Enemy.Spawn
{
    public partial class EnemiesSpawn : MonoBehaviour, IEnemiesSpawn
    {
        public static IEnemiesSpawn Instance;

        private IMatchRegulator UsedMatchRegulator => MatchRegulator.Instance;
        private EnemyConfig UsedEnemyConfig => EnemyConfig.Instance;
        private EnemySpawnConfig UsedEnemySpawnConfig => EnemySpawnConfig.Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UsedMatchRegulator.ResetMatch.AddListener(SpawnEnemies);
        }

        private void SpawnEnemies()
        {
            var position = Vector3.zero;
            for (var i = 0; i < UsedEnemySpawnConfig.EnemiesCount; i++)
            {
                var breakCounter = 10000;
                while (TooCloseToOtherEnemies(position) && breakCounter > 0)
                {
                    breakCounter--;
                    position = RandomSpawnPosition;
                }

                if (breakCounter == 0)
                {
                    Debug.LogWarning("no place for more enemies");
                    return;
                }

                var enemy = GetEnemyFromPoolTo(position);
                if (enemy == null)
                {
                    enemy = CreateNewEnemy(position);
                }
                _enemiesOnBoard.Add(enemy);
            }
        }

        private Vector3 RandomSpawnPosition
        {
            get
            {
                var xPos = UnityEngine.Random.Range(-UsedEnemySpawnConfig.SpawnZoneWidth,
                    UsedEnemySpawnConfig.SpawnZoneWidth);
                var zPos = UnityEngine.Random.Range(-UsedEnemySpawnConfig.SpawnZoneLength,
                    UsedEnemySpawnConfig.SpawnZoneLength);

                return new Vector3(xPos, 0, zPos);
            }
        }

        private bool TooCloseToOtherEnemies(Vector3 position)
        {
            return _enemiesOnBoard.Any(enemyView =>
                Vector3.Distance(position, enemyView.transform.localPosition) <
                UsedEnemySpawnConfig.MinDistanceBetween);
        }
    }
}