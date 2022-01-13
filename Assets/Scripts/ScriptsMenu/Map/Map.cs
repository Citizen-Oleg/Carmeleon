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

        private BubbleSortLevels _bubbleSortLevels;
        
        private void Awake()
        {
            _bubbleSortLevels = new BubbleSortLevels();
            SortLevels();
            OpeningStartLocation();
            
            var passedLevels = GameManager.PlayerData.PassedLevel;
            SetPassedLevels(passedLevels);
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
                    level.LevelData = levelData;
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
                    level.LevelData = passedLevel.LevelData;
                    level.Refresh();
                }
            }
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

        private void SortLevels()
        {
            _levels = _bubbleSortLevels.Sort(_levels);
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