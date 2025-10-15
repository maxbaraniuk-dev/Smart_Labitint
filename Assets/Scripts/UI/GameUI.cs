using System;
using Events;
using TMPro;
using UI.Core;
using UnityEngine;

namespace UI
{
    public class GameUI : BaseView
    {
        [SerializeField] TMP_Text timeText;
        [SerializeField] TMP_Text distanceText;

        public override void Show()
        {
            EventsMap.Subscribe<float>(GameEvents.OnPlayerDistanceUpdated, PassedDistanceUpdateListener);
            EventsMap.Subscribe<float>(GameEvents.OnTimeUpdated, TimeUpdateListener);
        }

        protected override void CloseInternal()
        {
            EventsMap.Unsubscribe<float>(GameEvents.OnPlayerDistanceUpdated, PassedDistanceUpdateListener);
            EventsMap.Unsubscribe<float>(GameEvents.OnTimeUpdated, TimeUpdateListener);
        }

        private void PassedDistanceUpdateListener(float distance)
        {
            distanceText.text = $"{distance:F1}m";
        }
        
        private void TimeUpdateListener(float time)
        {
            timeText.text = $"{TimeSpan.FromSeconds(time):mm\\:ss}";
        }
    }
}