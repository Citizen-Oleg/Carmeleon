using System.Collections.Generic;
using ScreenManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptsMenu.Map
{
    public class Map : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Region _startRegion;
        
        [SerializeField]
        private List<Region> _regions;
        [SerializeField]
        private List<Level> _levels;
        
        private void Awake()
        {
            _levels = new BubbleSortLevels().Sort(_levels);
            OpeningStartLocation();
            SetPassedLevels(GameManager.PlayerData.PassedLevel);
            OpeningRegions();
        }
        
        private void SetPassedLevels(List<Level> passedLevels)
        {
            foreach (var passedLevel in passedLevels)
            {
                var levelData = passedLevel.LevelData;
                if (levelData.ID == _levels[levelData.ID].LevelData.ID)
                {
                    var level = _levels[levelData.ID];
                    SetMatchLevelData(level.LevelData, levelData);
                    level.OpenLevel();
                    level.OpenNextLevel();
                    level.Refresh();
                }
                else
                {
                    SetPassedLevel(passedLevel);
                }
            }
        }
        
        private void SetPassedLevel(Level passedLevel)
        {
            for (int i = passedLevel.LevelData.ID; i < _levels.Count; i++)
            {
                if (passedLevel.LevelData.ID == _levels[i].LevelData.ID)
                {
                    var level = _levels[i];
                    SetMatchLevelData(level.LevelData, passedLevel.LevelData);
                    level.OpenLevel();
                    level.OpenNextLevel();
                    level.Refresh();
                    return;
                }
            }
        }

        private void SetMatchLevelData(LevelData level, LevelData passedLevel)
        {
            level.IsOpen = passedLevel.IsOpen;
            level.IsPassedEasyLevel = passedLevel.IsPassedEasyLevel;
            level.IsPassedAverageLevel = passedLevel.IsPassedAverageLevel;
            level.IsPassedHighLevel = passedLevel.IsPassedHighLevel;
            level.HasGoldBorder = passedLevel.HasGoldBorder;
        }

        private void OpeningRegions()
        {
            foreach (var region in _regions)
            {
                if (region.IsPassed)
                {
                    region.DiscoveryNeighboringTerritories();
                }
            }
        }

        private void OpeningStartLocation()
        {
            _startRegion.TerritoryDiscovery();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (GameManager.ScreenManager.IsScreenOpened(ScreenType.LevelScreen))
            {
                GameManager.ScreenManager.CloseTopScreen();
            }
        }
    }

    class BubbleSortLevels
    {
        public List<Level> Sort(List<Level> levels)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                for (int j = i + 1; j < levels.Count; j++)
                {
                    if (levels[i].LevelData.ID > levels[j].LevelData.ID)
                    {
                        (levels[i], levels[j]) = (levels[j], levels[i]);
                    }
                }
            }

            return levels;
        }
    }
}