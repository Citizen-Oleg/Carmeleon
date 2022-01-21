using System;
using System.Linq;
using Player;
using ResourceManager;
using ScreenManager;
using ScriptsLevels.ContextScreen;
using ScriptsLevels.Event;
using ScriptsMenu.Map;
using SimpleEventBus;
using UnityEngine;

namespace ScriptsLevels.Level
{
    public class ResultLevel : MonoBehaviour
    {
        private const int REWARD_FOR_PASSED_MODE = 1;
        private const int NUMBER_OF_MODIFICATORS_TO_START_ADVANCED_LEVEL = 2;
        private const int NUMBER_OF_MODIFICATORS_FOR_GOLDEN_RIMS = 5;
        
        [SerializeField]
        private PlayerBase _playerBase;
        
        private IDisposable _subscription;
        
        private void Awake()
        {
            _subscription = EventStreams.UserInterface.Subscribe<EventCompletingLevel>(Summarizing);
        }

        private void Summarizing(EventCompletingLevel completingLevel)
        {
            Time.timeScale = 0;
            if (_playerBase.CurrentHp <= 0)
            {
                Lose();
            }
            else
            {
                Victory();
            }
        }

        private void Lose()
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.LoseScreen);
        }

        private void Victory()
        {
            var levelData = GameManager.instance.CurrentLevel.LevelData;

            foreach (var modifier in levelData.Modifiers.Where(modifier => modifier.IsActive))
            {
                modifier.IsPassed = true;
            }

            CheckPatencyGoldStroke(levelData);
            
            GameManager.PlayerData.AddPassedLevel(GameManager.instance.CurrentLevel.LevelData);
            
            var context = new VictoryScreenContext(
                CheckEasyPatencyLevel(levelData), CheckAveragePatencyLevel(levelData), CheckHighPatencyLevel(levelData));
            GameManager.ScreenManager.OpenScreenWithContext(ScreenType.VictoryScreen, context);
        }

        private bool CheckEasyPatencyLevel(LevelData levelData)
        {
            if (!levelData.IsPassedEasyLevel)
            {
                levelData.IsPassedEasyLevel = true;
                AwardAccrual();
                return true;
            }

            return false;
        }
        
        private bool CheckAveragePatencyLevel(LevelData levelData)
        {
            var hasLostHP = _playerBase.CurrentHp < _playerBase.MAXHp;
            if (!hasLostHP && !levelData.IsPassedAverageLevel)
            {
                levelData.IsPassedAverageLevel = true;
                AwardAccrual();
                return true;
            }
            return false;
        }
        
        private bool CheckHighPatencyLevel(LevelData levelData)
        {
            var hasLostHP = _playerBase.CurrentHp < _playerBase.MAXHp;
            if (levelData.Modifiers.Count(modifier => modifier.IsActive) >= NUMBER_OF_MODIFICATORS_TO_START_ADVANCED_LEVEL 
                && !hasLostHP && !levelData.IsPassedHighLevel)
            {
                levelData.IsPassedHighLevel = true;
                AwardAccrual();
                return true;
            }
            return false;
        }

        private bool CheckPatencyGoldStroke(LevelData levelData)
        {
            var hasLostHP = _playerBase.CurrentHp < _playerBase.MAXHp;
            if (levelData.Modifiers.Count(modifier => modifier.IsActive) == NUMBER_OF_MODIFICATORS_FOR_GOLDEN_RIMS && !hasLostHP)
            {
                levelData.HasGoldBorder = true;
                return true;
            }

            return false;
        }

        private void AwardAccrual()
        {
            GameManager.ResourceManagerGame.AddResource(ResourceType.Splinter, REWARD_FOR_PASSED_MODE);
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}
