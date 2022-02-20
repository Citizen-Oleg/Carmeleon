using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsMenu.Map
{
    public class Region : MonoBehaviour
    {
        public bool IsOpen { get; private set; }
        public bool IsPassed => _levels.All(level => level.LevelData.IsPassedEasyLevel);
        
        [SerializeField]
        private List<Region> _neighboringRegions;
        [SerializeField]
        private Level _startLevel;
        [SerializeField]
        private Level _bonusLevel;
        [Header("No bonus levels")]
        [SerializeField]
        private List<Level> _levels = new List<Level>();
        
        public void TerritoryDiscovery()
        {
            IsOpen = true;
            _startLevel.OpenLevel();
        }

        public void DiscoveryNeighboringTerritories()
        {
            if (_bonusLevel != null)
            {
                _bonusLevel.OpenLevel();
            }

            foreach (var neighboringRegion in _neighboringRegions)
            {
                neighboringRegion.TerritoryDiscovery();
            }
        }
    }
}
