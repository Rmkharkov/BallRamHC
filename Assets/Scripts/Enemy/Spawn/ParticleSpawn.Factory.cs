using UnityEngine;

namespace Enemy.Spawn
{
    public partial class ParticleSpawn
    {
        private EnemyConfig UsedEnemyConfig => EnemyConfig.Instance;

        private ParticleSystem CreateNewParticle(Vector3 localPosition)
        {
            var particle = Instantiate(UsedEnemyConfig.DeathParticlePrefab, onBoardParent);
            particle.transform.localPosition = localPosition;

            return particle;
        }
    }
}