using Events;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LobbyMainDialog : BaseView
    {
        [SerializeField] Button playButton;
        [SerializeField] Button savesButton;
        [SerializeField] Button leaderboardButton;

        public override void Show()
        {
            playButton.onClick.AddListener(OnPlayButton);
            savesButton.onClick.AddListener(() => EventsMap.Dispatch(UIEvents.OnShowSaves));
            leaderboardButton.onClick.AddListener(() => EventsMap.Dispatch(UIEvents.OnShowResults));
        }

        private void OnPlayButton()
        {
            EventsMap.Dispatch(UIEvents.OnPrepareNewGame);
            Close();
        }
    }
}