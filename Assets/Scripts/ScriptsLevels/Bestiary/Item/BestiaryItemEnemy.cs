using BuffSystem.SettingsBuff;
using EnemyComponent;
using ScriptsLevels.Inventory;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BestiaryItem/Enemy", order = 2)]
    public class BestiaryItemEnemy : BestiaryItem<EnemyItem>
    {
        public SettingsBuff<Enemy> SettingsBuffEnemy => _settingsBuffEnemy;
        public SettingsBuff<Tower> SettingsDebuffTower => _settingsDebuffTower;

        [SerializeField]
        private SettingsBuff<Enemy> _settingsBuffEnemy;
        [SerializeField]
        private SettingsBuff<Tower> _settingsDebuffTower;
    }
}