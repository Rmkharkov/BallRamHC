using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemiesController
    {
        private static readonly List<IEnemyView> Enemies = new List<IEnemyView>();
        
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