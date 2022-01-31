using System;
using System.Linq;
using Player;
using ResourceManager;
using ScreenManager;
using ScriptsLevels.ContextScreen;
using ScriptsLevels.Event;
using ScriptsLevels.Providers;
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

            var activeModifier = levelData.Modifiers.Where(modifier => modifier.IsActive).ToList();
            foreach (var modifier in activeModifier)
            {
                modifier.IsPassed = true;
            }
            
            var context = new VictoryScreenContext(
                CheckEasyPatencyLevel(levelData), CheckAveragePatencyLevel(levelData), CheckHighPatencyLevel(levelData),
                activeModifier.Count);
            GameManager.PlayerData.AddPassedLevel(GameManager.instance.CurrentLevel.LevelData);
            GameManager.ScreenManager.OpenScreenWithContext(ScreenType.VictoryScreen, context);
        }

        private SpriteType CheckEasyPatencyLevel(LevelData levelData)
        {
            if (levelData.IsPassedEasyLevel)
            {
                return SpriteType.ReceivedCrystal;
            }

            levelData.IsPassedEasyLevel = true;
            AwardAccrual();
            return SpriteType.ReceivedCrystalReward;
        }
        
        private SpriteType CheckAveragePatencyLevel(LevelData levelData)
        {
            var hasLostHP = _playerBase.CurrentHp < _playerBase.MAXHp;

            if (!hasLostHP && !levelData.IsPassedAverageLevel)
            {
                levelData.IsPassedAverageLevel = true;
                AwardAccrual();
                return SpriteType.ReceivedCrystalReward;
            }
            
            if (!hasLostHP && levelData.IsPassedAverageLevel)
            {
                return SpriteType.ReceivedCrystal;
            }
            
            return SpriteType.NotReceivedCrystal;
        }
        
        private SpriteType CheckHighPatencyLevel(LevelData levelData)
        {
            var hasLostHP = _playerBase.CurrentHp < _playerBase.MAXHp;
            var isMaxModificator = levelData.Modifiers.Count(modifier => modifier.IsActive) >= NUMBER_OF_MODIFICATORS_TO_START_ADVANCED_LEVEL;

            if (isMaxModificator && !hasLostHP && levelData.IsPassedHighLevel)
            {
                return SpriteType.ReceivedCrystal;
            }
            
            if (isMaxModificator && !hasLostHP && !levelData.IsPassedHighLevel)
            {
                levelData.HasGoldBorder = true;
                levelData.IsPassedHighLevel = true;
                AwardAccrual();
                return SpriteType.ReceivedCrystalReward;
            }
            return SpriteType.NotReceivedCrystal;
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
