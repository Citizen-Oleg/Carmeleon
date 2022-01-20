using System.Collections.Generic;
using BuffSystem.SettingsBuff;
using ScriptsLevels.Inventory;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BestiaryItem/Tower", order = 0)]
    public class BestiaryItemTower : BestiaryItem<TowerItem>
    {
        public SettingsBuff<Tower> SettingsBuff => _settingsBuff;
        public Sprite SpriteCraftItem => _spriteCraftItem;

        [SerializeField]
        private SettingsBuff<Tower> _settingsBuff;
        [SerializeField]
        private Sprite _spriteCraftItem;
    }
}