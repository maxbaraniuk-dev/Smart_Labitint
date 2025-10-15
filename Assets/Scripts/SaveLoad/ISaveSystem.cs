using Game;
using Game.Level;
using Infrastructure;

namespace SaveLoad
{
    public interface ISaveSystem : ISystem
    {
        void SaveCompletedLevel(LevelResultData levelResult);
        public AchievementsData LoadLevelsStat();
    }
}