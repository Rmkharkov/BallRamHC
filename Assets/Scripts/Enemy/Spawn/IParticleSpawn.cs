using UnityEngine;

namespace Enemy.Spawn
{
    public interface IParticleSpawn
    {
        void SpawnParticle(Vector3 localPosition);
    }
}