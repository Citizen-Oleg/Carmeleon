using Inventory;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TowerItem", order = 1)]
    public class TowerItem : Item
    {
        public Tower Tower
        {
            get => _tower;
            set => _tower = value;
        }

        public GhostTower GhostTower
        {
            get => _ghostTower;
            set => _ghostTower = value;
        }

        [SerializeField]
        private Tower _tower;
        [SerializeField]
        private GhostTower _ghostTower;
    }
}