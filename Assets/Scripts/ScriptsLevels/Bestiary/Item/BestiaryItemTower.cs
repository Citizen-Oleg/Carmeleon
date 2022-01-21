using System.Collections.Generic;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using ScriptsLevels.Inventory;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BestiaryItem/Tower", order = 0)]
    public class BestiaryItemTower : BestiaryItem<TowerItem>
    {
        public Sprite SpriteCraftItem => _spriteCraftItem;

        public SettingsBuff<Enemy> SettingsDebuffEnemy => _settingsDebuffEnemy;
        public SettingsBuff<Tower> SettingsBuffTower => _settingsBuffTower;

        [SerializeField]
        private SettingsBuff<Enemy> _settingsDebuffEnemy;
        [SerializeField]
        private SettingsBuff<Tower> _settingsBuffTower;
        [SerializeField]
        private Sprite _spriteCraftItem;
    }
}