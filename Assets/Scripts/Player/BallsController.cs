using System;
using System.Threading;
using System.Threading.Tasks;
using Enemy;
using Game;
using Target;
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
        [SerializeField] private RoadPathView roadPathView;
        private IBallSourceView UsedBallSourceView => ballSourceView;
        private IBulletBallView UsedBulletBallView => bulletBallView;
        private IBulletBallTrigger UsedBulletBallTrigger => bulletBallTrigger;
        private IBulletBallMoving UsedBulletBallMoving => bulletBallMoving;

        private IRoadPathView UsedRoadPathView => roadPathView;
        
        public UnityEvent LostSourceBall { get; } = new UnityEvent();
        public UnityEvent BallArrivedToGarage { get; } = new UnityEvent();
        
        private bool _isOnMove;
        private bool _arrivedToTarget;
        
        private IGameplayInput GameplayInputInstance => GameplayInput.Instance;
        private IMatchRegulator UsedMatchRegulator => MatchRegulator.Instance;
        private ITargetController UsedTargetController => TargetController.Instance;
        private PlayerConfig UsedPlayerConfig => PlayerConfig.Instance;

        private CancellationTokenSource _ctsGrowth;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameplayInputInstance.StartGrowth.AddListener(OnStartGrowth);
            GameplayInputInstance.EndGrowth.AddListener(OnEndGrowth);
            UsedBulletBallTrigger.HitEnemyEvent.AddListener(OnHitEnemy);
            UsedMatchRegulator.ResetMatch.AddListener(Reset);
            UsedTargetController.TargetTrigger.BallArrived.AddListener(OnArrivedToGarageEntrance);
            UsedBulletBallTrigger.ArrivedToGarage.AddListener(OnArrivedToGarage);
        }

        private void Reset()
        {
            UsedBulletBallMoving.Stop();
            UsedBallSourceView.ResetSize();
            UsedBulletBallView.ResetSize();
            UsedRoadPathView.ResetSize();
            UsedBulletBallTrigger.ResetSize();
            UsedBulletBallMoving.ResetPosition();
            _isOnMove = false;
            _arrivedToTarget = false;
        }

        private async void OnStartGrowth()
        {
            if (_isOnMove || _arrivedToTarget)
            {
                return;
            }
            _ctsGrowth = new CancellationTokenSource();
            await AsyncGrowthTask(_ctsGrowth.Token);
        }

        private void OnEndGrowth()
        {
            if (_isOnMove || _arrivedToTarget || _ctsGrowth.IsCancellationRequested)
            {
                return;
            }
            _ctsGrowth.Cancel();
            StartMoving();
        }

        private async void OnHitEnemy()
        {
            UsedBulletBallMoving.Stop();
            await Task.Delay(TimeSpan.FromSeconds(UsedPlayerConfig.AfterEnemyHitDelay));
            UsedBulletBallView.ResetSize();
            UsedBulletBallTrigger.ResetSize();
            UsedBulletBallMoving.ResetPosition();
            
            _isOnMove = false;
        }

        private void OnArrivedToGarage()
        {
            UsedBulletBallMoving.Stop();
            BallArrivedToGarage.Invoke();
        }

        private void OnArrivedToGarageEntrance()
        {
            _arrivedToTarget = true;
        }

        private async Task AsyncGrowthTask(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (UsedBallSourceView.Decrease(UsedPlayerConfig.DecreaseSourceSpeed, UsedPlayerConfig.MinimumSourceScale))
                    {
                        UsedRoadPathView.DecreaseWidth(UsedPlayerConfig.DecreaseSourceSpeed);
                        UsedBulletBallView.Growth(UsedPlayerConfig.GrowBulletSpeed);
                        UsedBulletBallTrigger.Growth(UsedPlayerConfig.GrowBulletSpeed * UsedPlayerConfig.GrowBulletColliderFactor);
                    }
                    else
                    {
                        _ctsGrowth.Cancel();
                        LostSourceBall.Invoke();
                        break;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(UsedPlayerConfig.ScaleTimeStamp), token);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void StartMoving()
        {
            _isOnMove = true;
            UsedBulletBallMoving.Shoot(UsedPlayerConfig.MoveSpeed);
        }
    }
}