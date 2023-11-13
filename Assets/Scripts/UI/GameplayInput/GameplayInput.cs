using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.GameplayInput
{
    public class GameplayInput : MonoBehaviour, IGameplayInput
    {
        public static IGameplayInput Instance;
        public UnityEvent StartGrowth { get; } = new UnityEvent();
        public UnityEvent EndGrowth { get; } = new UnityEvent();
        
        [SerializeField] private EventTrigger fireButton;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            var onStartTouch = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerDown
            };
            onStartTouch.callback.AddListener(OnButtonPress);
            
            var onEndTouch = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerUp
            };
            onEndTouch.callback.AddListener(OnButtonRelease);
            
            fireButton.triggers.Add(onStartTouch);
            fireButton.triggers.Add(onEndTouch);
        }

        private void OnButtonPress(BaseEventData data)
        {
            StartGrowth.Invoke();
        }

        private void OnButtonRelease(BaseEventData data)
        {
            EndGrowth.Invoke();
        }
    }
}