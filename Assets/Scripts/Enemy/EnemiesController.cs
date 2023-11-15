using System.Collections.Generic;
using System.Linq;
using Enemy.Spawn;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemiesController
    {
        private static readonly List<IEnemyView> Enemies = new List<IEnemyView>();
        private static IEnemiesSpawn UsedEnemiesSpawn => EnemiesSpawn.Instance;
        
        public static void AddEnemyView(IEnemyView enemy)
        {
            if (!Enemies.Contains(enemy))
            {
                Enemies.Add(enemy);
            } 
        }

        public static void ResetEnemies()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Init();
            }
        }
    }
}