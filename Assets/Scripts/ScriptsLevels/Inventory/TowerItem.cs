﻿using Inventory;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/TowerItem", order = 1)]
    public class TowerItem : Item
    {
        public override string Name => _tower.Name;

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