using System;
using Events;
using Game;
using TMPro;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompleteDialog : BaseDataView<LevelResultData>
    {
        [SerializeField] TMP_Text timeText;
        [SerializeField] TMP_Text distanceText;
        [SerializeField] TMP_Text levelText;
        [SerializeField] Button confirmButton;

        public override void Show<T>(T viewModel)
        {
            base.Show(viewModel);
            timeText.text = $"{TimeSpan.FromSeconds(ViewModel.time):mm\\:ss}";
            distanceText.text = $"{ViewModel.distance:F1}m";
            confirmButton.onClick.AddListener(OnConfirm);
            //levelText.text = ViewModel.
        }

        private void OnConfirm()
        {
            EventsMap.Dispatch(UIEvents.OnBackToMenu);
            Close();
        }
    }
}