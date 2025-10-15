using System.Collections.Generic;
using Events;
using Game;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DifficultySelectDialog : BaseView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Toggle easyToggle;
        [SerializeField] private Toggle mediumToggle;
        [SerializeField] private Toggle hardToggle;

        private readonly Dictionary<Toggle, DifficultyLevel> _difficultyToggles = new();
        
        private DifficultyLevel _difficultyLevel;
        
        public override void Show()
        {
            _difficultyToggles.Add(easyToggle, DifficultyLevel.Easy);
            _difficultyToggles.Add(mediumToggle, DifficultyLevel.Medium);
            _difficultyToggles.Add(hardToggle, DifficultyLevel.Hard);
            
            foreach (var activeToggle in _difficultyToggles.Keys)
                activeToggle.onValueChanged.AddListener(_ => OnToggleValueChanged(activeToggle));
            
            mediumToggle.isOn = true;
            playButton.onClick.AddListener(OnStartGame);
        }

        private void OnToggleValueChanged(Toggle toggle)
        {
            _difficultyLevel = _difficultyToggles[toggle];
        }
        
        private void OnStartGame()
        {
            EventsMap.Dispatch(UIEvents.OnStartNewGame, _difficultyLevel);
            Close();
        }
    }
}