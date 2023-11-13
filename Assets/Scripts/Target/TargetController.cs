using System;
using Game;
using Player;
using UnityEngine;

namespace Target
{
    public class TargetController : MonoBehaviour, ITargetController
    {
        public static ITargetController Instance;
        
        [SerializeField] private TargetDoorView targetDoorView;
        private ITargetDoorView TargetDoorView => targetDoorView;
        [SerializeField] private TargetTrigger targetTrigger;
        public ITargetTrigger TargetTrigger => targetTrigger;
        
        private IMatchRegulator UsedMatchRegulator => MatchRegulator.Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UsedMatchRegulator.ResetMatch.AddListener(ResetDoor);
            TargetTrigger.BallArrived.AddListener(OpenDoor);
        }

        void ResetDoor()
        {
            TargetDoorView.CloseDoor();
        }

        void OpenDoor()
        {
            TargetDoorView.OpenDoor();
        }
    }
}