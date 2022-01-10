using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptsMenu.Map
{
    public class Region : MonoBehaviour
    {
        public bool IsOpen => _isOpen;
        public bool IsPassed => _levels.All(level => level.LevelData.IsPassedEasyLevel);
        
        [SerializeField]
        private Level _startLevel;
        [SerializeField]
        private List<Region> _neighboringRegions;
        [SerializeField]
        private List<Level> _levels = new List<Level>();
        
        private bool _isOpen;
        
        public void TerritoryDiscovery()
        {
            _isOpen = true;
            _startLevel.OpenLevel();
        }

        public void DiscoveryNeighboringTerritories()
        {
            foreach (var neighboringRegion in _neighboringRegions)
            {
                neighboringRegion.TerritoryDiscovery();
            }
        }
    }
}
