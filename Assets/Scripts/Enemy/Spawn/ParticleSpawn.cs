using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemy.Spawn
{
    public partial class ParticleSpawn : MonoBehaviour, IParticleSpawn
    {
        public static IParticleSpawn Instance;

        private void Awake()
        {
            Instance = this;
        }

        public async void SpawnParticle(Vector3 localPosition)
        {
            var usedPosition = ParsedPosition(localPosition);
            var particle = UseParticleFromPool(usedPosition);
            if (particle == null)
            {
                particle = CreateNewParticle(usedPosition);
            }
            particle.Play();
            await Task.Delay(TimeSpan.FromSeconds(particle.main.startLifetime.constant));
            PutParticleInPool(particle);
        }

        private Vector3 ParsedPosition(Vector3 position)
        {
            return new Vector3(position.x, UsedEnemyConfig.DeathParticlePrefab.transform.localPosition.y, position.z);
        }
    }
}