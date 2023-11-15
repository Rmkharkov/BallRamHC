using System;
using System.Threading.Tasks;
using Enemy.Spawn;
using Game;
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
        private IEnemiesSpawn UsedEnemiesSpawn => EnemiesSpawn.Instance;
        private IMatchRegulator UsedMatchRegulator => MatchRegulator.Instance;
        private IParticleSpawn UsedParticleSpawn => ParticleSpawn.Instance;
        private EnemyConfig UsedEnemyConfig => EnemyConfig.Instance;
        private EEnemyState _currentState;

        public bool IsSick => _currentState == EEnemyState.Infected;

        private void Start()
        {
            EnemiesController.AddEnemyView(this);
            UsedMatchRegulator.LostMatch.AddListener(HideMe);
            UsedMatchRegulator.WonMatch.AddListener(HideMe);
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
            SetState(EEnemyState.Dead);
            UsedParticleSpawn.SpawnParticle(transform.localPosition);
            UsedEnemiesSpawn.HideEnemy(this);
        }

        private void SetState(EEnemyState state)
        {
            _currentState = state;
            if (bodyRenderer != null)
            {
                bodyRenderer.sharedMaterial = UsedEnemyMaterialsConfig.GetStateMaterial(state);
            }
        }

        private void HideMe()
        {
            UsedEnemiesSpawn.HideEnemy(this);
        }
    }
}