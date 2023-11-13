using System;
using System.Threading;
using System.Threading.Tasks;
using UI;
using UI.GameplayInput;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class BallsController : MonoBehaviour, IBallsController
    {
        public static IBallsController Instance;
        
        [SerializeField] private BallSourceView ballSourceView;
        [SerializeField] private BulletBallView bulletBallView;
        [SerializeField] private BulletBallTrigger bulletBallTrigger;
        [SerializeField] private BulletBallMoving bulletBallMoving;
        private IBallSourceView UsedBallSourceView => ballSourceView;
        private IBulletBallView UsedBulletBallView => bulletBallView;
        private IBulletBallTrigger UsedBulletBallTrigger => bulletBallTrigger;
        private IBulletBallMoving UsedBulletBallMoving => bulletBallMoving;
        
        public UnityEvent LostSourceBall { get; } = new UnityEvent();
        
        private IGameplayInput GameplayInputInstance => GameplayInput.Instance;
        private PlayerConfig UsedPlayerConfig => PlayerConfig.Instance;

        private CancellationTokenSource _ctsGrowth;
        private CancellationTokenSource _ctsMoving;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameplayInputInstance.StartGrowth.AddListener(OnStartGrowth);
            GameplayInputInstance.EndGrowth.AddListener(OnEndGrowth);
            UsedBulletBallTrigger.HitEnemy.AddListener(OnHitEnemy);
        }

        private async void OnStartGrowth()
        {
            _ctsGrowth = new CancellationTokenSource();
            await AsyncGrowthTask(_ctsGrowth.Token);
        }

        private void OnEndGrowth()
        {
            _ctsGrowth.Cancel();
            StartMoving();
        }

        private void OnHitEnemy()
        {
            _ctsMoving.Cancel();
        }

        private async Task AsyncGrowthTask(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (UsedBallSourceView.Decrease(UsedPlayerConfig.DecreaseSourceSpeed, UsedPlayerConfig.MinimumSourceScale))
                    {
                        UsedBulletBallView.Growth(UsedPlayerConfig.GrowBulletSpeed);
                    }
                    else
                    {
                        LostSourceBall.Invoke();
                        OnEndGrowth();
                        break;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(UsedPlayerConfig.ScaleTimeStamp), token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async void StartMoving()
        {
            _ctsMoving = new CancellationTokenSource();
            await UsedBulletBallMoving.AsyncMovingTask(UsedPlayerConfig.MoveSpeed, UsedPlayerConfig.MovingTimeStamp,
                _ctsMoving.Token);
        }
    }
}