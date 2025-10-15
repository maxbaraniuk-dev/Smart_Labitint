using Events;
using Game;
using Infrastructure;
using UI;

namespace AppStates
{
    public class GameState : IPayLoadedState<DifficultyLevel>
    {
        private DifficultyLevel _difficultyLevel;
        public void SetPayload(DifficultyLevel payload)
        {
            _difficultyLevel = payload;
        }

        public void Enter()
        {
            Context.GetSystem<UISystem>().ShowView<GameUI>();
            Context.GetSystem<GameSystem>().StartNewGame(_difficultyLevel);
            EventsMap.Subscribe(UIEvents.OnBackToMenu, OnBackToMenu);
        }

        private void OnBackToMenu()
        {
            Context.AppStateMachine.Enter<LobbyState>();
        }

        public void Exit()
        {
            Context.GetSystem<GameSystem>().ExitGame();
            EventsMap.Unsubscribe(UIEvents.OnBackToMenu, OnBackToMenu);
        }
    }
}