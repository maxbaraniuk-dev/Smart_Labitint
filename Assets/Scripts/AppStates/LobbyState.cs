using Events;
using Game;
using Game.Level;
using Infrastructure;
using SaveLoad;
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
            EventsMap.Subscribe(UIEvents.OnShowResults, OnShowResults);
            
            EventsMap.Subscribe<DifficultyLevel>(UIEvents.OnStartNewGame, OnStartNewGame);
        }

        public void Exit()
        {
            Context.GetSystem<UISystem>().CloseView<LobbyBackground>();
            EventsMap.Unsubscribe(UIEvents.OnPrepareNewGame, OnPrepareNewGame);
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
            var achievements = Context.GetSystem<SaveSystem>().LoadLevelsStat();
            Context.GetSystem<UISystem>().ShowView<AchievementsDialog, AchievementsData>(achievements);
        }
        
        
        private void OnStartNewGame(DifficultyLevel difficultyLevel)
        {
            Context.AppStateMachine.Enter<GameState, DifficultyLevel>(difficultyLevel);
        }
    }
}