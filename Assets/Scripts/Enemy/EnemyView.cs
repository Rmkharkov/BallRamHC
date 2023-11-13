using System;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private MeshRenderer bodyRenderer;
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private EnemyGetHit enemyGetHit;
        [SerializeField] private EnemyInfection enemyInfection;
        public IEnemyGetHit EnemyGetHit => enemyGetHit;
        public IEnemyInfection EnemyInfection => enemyInfection;
        
        private EnemyMaterialsConfig UsedEnemyMaterialsConfig => EnemyMaterialsConfig.Instance;
        private EnemyConfig UsedEnemyConfig => EnemyConfig.Instance;

        private void Start()
        {
            EnemiesController.AddEnemyView(this);
        }

        public async void Init()
        {
            gameObject.SetActive(true);
            SetState(EEnemyState.Healthy);
            enemyGetHit.Init(this);
            enemyInfection.Init(this);
            
            await Task.Yield();

            enemyInfection.InfectedEvent.AddListener(OnInfected);
        }

        private async void OnInfected()
        {
            SetState(EEnemyState.Infected);
            await Task.Delay(TimeSpan.FromSeconds(UsedEnemyConfig.InfectToDeathDelay));
            gameObject.SetActive(false);
        }

        private void SetState(EEnemyState state)
        {
            if (bodyRenderer != null)
            {
                bodyRenderer.sharedMaterial = UsedEnemyMaterialsConfig.GetStateMaterial(state);
            }
        }
    }
}