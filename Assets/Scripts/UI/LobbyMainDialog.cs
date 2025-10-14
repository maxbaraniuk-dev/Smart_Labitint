using Cysharp.Threading.Tasks;
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

        public override UniTask Show()
        {
            playButton.onClick.AddListener(() => EventsMap.Dispatch(UIEvents.OnPrepareNewGame));
            savesButton.onClick.AddListener(() => EventsMap.Dispatch(UIEvents.OnShowSaves));
            leaderboardButton.onClick.AddListener(() => EventsMap.Dispatch(UIEvents.OnShowResults));
            return base.Show();
        }

        public override UniTask Close()
        {
            
            return base.Close();
        }
    }
}