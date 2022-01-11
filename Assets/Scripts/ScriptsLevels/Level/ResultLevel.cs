using System;
using Player;
using ResourceManager;
using ScreenManager;
using ScriptsLevels.ContextScreen;
using ScriptsLevels.Event;
using SimpleEventBus;
using UnityEngine;

namespace ScriptsLevels.Level
{
    public class ResultLevel : MonoBehaviour
    {
        private const int REWARD_FOR_PASSED_MODE = 1;
        
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
            var easyLevel = false;
            var averageLevel = false;
            var highLevel = false;

            if (_playerBase.CurrentHp <= _playerBase.MAXHp && !levelData.IsPassedEasyLevel)
            {
                levelData.IsPassedEasyLevel = true;
                easyLevel = true;
                AwardAccrual();
            }

            if (_playerBase.MAXHp == _playerBase.CurrentHp && !levelData.IsPassedAverageLevel)
            {
                levelData.IsPassedAverageLevel = true;
                averageLevel = true;
                AwardAccrual();
            }
            
            //TODO: Если 5 модификаторов и не получил урона то highLevel = true;
            
            GameManager.PlayerData.AddPassedLevel(GameManager.instance.CurrentLevel);
            var context = new VictoryScreenContext(easyLevel, averageLevel, highLevel);
            GameManager.ScreenManager.OpenScreenWithContext(ScreenType.VictoryScreen, context);
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
