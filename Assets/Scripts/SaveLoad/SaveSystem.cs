using System.Collections.Generic;
using Game;
using Game.Level;
using UnityEngine;

namespace SaveLoad
{
    public class SaveSystem : MonoBehaviour, ISaveSystem
    {
        private const string LevelsDataKey = "levels";
        public void Initialize()
        {
        }
        
        public void Dispose()
        {
        }

        public void SaveCompletedLevel(LevelResultData levelResult)
        {
            var data = LocalStorage.Load<AchievementsData>(LevelsDataKey) ?? new AchievementsData{levels = new List<LevelResultData>()};
            data.levels.Add(levelResult);
            LocalStorage.Save(LevelsDataKey, data);
        }

        public AchievementsData LoadLevelsStat()
        {
            var data = LocalStorage.Load<AchievementsData>(LevelsDataKey) ?? new AchievementsData{levels = new List<LevelResultData>()};
            return data;
        }
    }
}