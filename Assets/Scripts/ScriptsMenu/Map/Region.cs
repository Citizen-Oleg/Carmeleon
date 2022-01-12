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

        [Header("UI data")]
        [SerializeField]
        private Image _region;
        [SerializeField]
        private Color _lockColor;
        [SerializeField]
        private Color _defaultColor;
        [Space]
        [SerializeField]
        private List<Region> _neighboringRegions;
        [SerializeField]
        private Level _startLevel;
        [SerializeField]
        private Level _bonusLevel;
        [Header("No bonus levels")]
        [SerializeField]
        private List<Level> _levels = new List<Level>();

        private void Start()
        {
            ChangeColor();
        }

        public void TerritoryDiscovery()
        {
            IsOpen = true;
            _startLevel.OpenLevel();
            ChangeColor();
        }

        public void DiscoveryNeighboringTerritories()
        {
            _bonusLevel.OpenLevel();
            foreach (var neighboringRegion in _neighboringRegions)
            {
                neighboringRegion.TerritoryDiscovery();
            }
        }

        private void ChangeColor()
        {
            _region.color = IsOpen ? _defaultColor : _lockColor;
        }
    }
}
