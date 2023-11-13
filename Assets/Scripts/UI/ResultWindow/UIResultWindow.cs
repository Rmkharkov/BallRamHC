using System;
using Game;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ResultWindow
{
    public class UIResultWindow : MonoBehaviour, IUIResultWindow
    {
        public static IUIResultWindow Instance;

        [SerializeField] private GameObject resultWindowObject;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private Button restartButton;
        private TextsConfig Texts => TextsConfig.Instance;
        
        public UnityEvent RestartPressed { get; } = new UnityEvent();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            MatchRegulator.Instance.LostMatch.AddListener(OnLost);
            MatchRegulator.Instance.WonMatch.AddListener(OnWon);
            restartButton.onClick.AddListener(OnRestartPressed);
        }

        void OnLost()
        {
            titleText.text = Texts.GetText(EText.ResultTitleLost);
            descriptionText.text = Texts.GetText(EText.ResultDescriptionLost);
            resultWindowObject.SetActive(true);
        }

        void OnWon()
        {
            titleText.text = Texts.GetText(EText.ResultTitleWon);
            descriptionText.text = Texts.GetText(EText.ResultDescriptionWon);
            resultWindowObject.SetActive(true);
        }

        void OnRestartPressed()
        {
            RestartPressed.Invoke();
            resultWindowObject.SetActive(false);
        }
    }
}