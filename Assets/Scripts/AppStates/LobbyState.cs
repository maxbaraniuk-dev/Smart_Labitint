using Events;
using Game;
using Infrastructure;
using UI;

namespace AppStates
{
    public class LobbyState : IState
    {
        public void Enter()
        {
            Context.GetSystem<UISystem>().ShowView<LobbyBackground>();
            Context.GetSystem<UISystem>().ShowView<LobbyMainDialog>();
            EventsMap.Subscribe(UIEvents.OnPrepareNewGame, OnPrepareNewGame);
            EventsMap.Subscribe(UIEvents.OnShowSaves, OnShowSaves);
            EventsMap.Subscribe(UIEvents.OnShowResults, OnShowResults);
            
            EventsMap.Subscribe<DifficultyLevel>(UIEvents.OnStartNewGame, OnStartNewGame);
        }

        public void Exit()
        {
            Context.GetSystem<UISystem>().CloseView<LobbyBackground>();
            EventsMap.Unsubscribe(UIEvents.OnPrepareNewGame, OnPrepareNewGame);
            EventsMap.Unsubscribe(UIEvents.OnShowSaves, OnShowSaves);
            EventsMap.Unsubscribe(UIEvents.OnShowResults, OnShowResults);
            
            EventsMap.Unsubscribe<DifficultyLevel>(UIEvents.OnStartNewGame, OnStartNewGame);
        }
        
        private void OnPrepareNewGame()
        {
            Context.GetSystem<UISystem>().CloseView<LobbyBackground>();
            Context.GetSystem<UISystem>().ShowView<DifficultySelectDialog>();
        }
        
        private void OnShowResults()
        {
            throw new System.NotImplementedException();
        }

        private void OnShowSaves()
        {
            throw new System.NotImplementedException();
        }
        
        private void OnStartNewGame(DifficultyLevel difficultyLevel)
        {
            Context.AppStateMachine.Enter<GameState, DifficultyLevel>(difficultyLevel);
        }
    }
}