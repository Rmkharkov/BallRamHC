using System;
using System.Threading.Tasks;
using Enemy;
using Player;
using UI.ResultWindow;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class MatchRegulator : MonoBehaviour, IMatchRegulator
    {
        public static IMatchRegulator Instance;
        
        public UnityEvent ResetMatch { get; } = new UnityEvent();
        public UnityEvent LostMatch { get; } = new UnityEvent();
        public UnityEvent WonMatch { get; } = new UnityEvent();
        
        private IUIResultWindow ResultWindow => UIResultWindow.Instance;
        private IBallsController UsedBallsController => BallsController.Instance;

        private void Awake()
        {
            Instance = this;
        }

        private async void Start()
        {
            ResultWindow.RestartPressed.AddListener(RestartMatch);
            UsedBallsController.LostSourceBall.AddListener(SetLoseMatch);
            UsedBallsController.BallArrivedToGarage.AddListener(SetWonMatch);
            await Task.Yield();
            RestartMatch();
        }

        private async void RestartMatch()
        {
            ResetMatch.Invoke();
            await Task.Yield();
            EnemiesController.ResetEnemies();
        }

        private void SetWonMatch()
        {
            WonMatch.Invoke();
        }

        private void SetLoseMatch()
        {
            LostMatch.Invoke();
        }
    }
}