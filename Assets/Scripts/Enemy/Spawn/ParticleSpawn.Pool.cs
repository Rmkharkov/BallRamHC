using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Spawn
{
    public partial class ParticleSpawn
    {
        [SerializeField] private Transform onBoardParent;
        [SerializeField] private Transform inPoolParent;
        private List<ParticleSystem> _particlesOnPool = new List<ParticleSystem>();

        private ParticleSystem UseParticleFromPool(Vector3 localPosition)
        {
            if (_particlesOnPool.Count > 0)
            {
                var particle = _particlesOnPool[0];
                _particlesOnPool.Remove(particle);
                particle.transform.SetParent(onBoardParent);
                particle.transform.localPosition = localPosition;

                return particle;
            }

            return null;
        }

        private void PutParticleInPool(ParticleSystem particle)
        {
            if (particle == null)
            {
                return;
            }
            particle.transform.SetParent(inPoolParent);
            _particlesOnPool.Add(particle);
        }
    }
}