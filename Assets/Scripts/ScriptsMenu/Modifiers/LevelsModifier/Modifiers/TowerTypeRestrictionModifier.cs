using System.Collections.Generic;
using Inventory;
using Level.ScriptsMenu.Interface;
using ScriptsLevels.Inventory;
using ScriptsLevels.Level;
using Towers;

namespace ScriptsMenu.Modifiers.LevelsModifier.Modifiers
{
    public class TowerTypeRestrictionModifier : IModifier
    {
        private readonly DamageType _damageType;
        private readonly PlayerData _playerData;
        
        public TowerTypeRestrictionModifier(DamageType damageType, PlayerData playerData)
        {
            _damageType = damageType;
            _playerData = playerData;
        }
        
        public void Activate()
        {
            var standardTower = _playerData.StandardTowerLevel;
            RemoveTowersWrongType(standardTower);

            var improvedTowers = _playerData.ImprovedLevelTowers;
            RemoveTowersWrongType(improvedTowers);

            var recipeTowers = LevelManager.ItemsManager.ItemsWithCraft;
            RemoveTowersWrongType(recipeTowers);
        }

        private void RemoveTowersWrongType(List<InventoryItem> towerItems)
        {
            for (int i = 0; i < towerItems.Count; i++)
            {
                var item = (TowerItem) towerItems[i].Item;
                if (item.Tower.TowerCharacteristics.DamageType == _damageType)
                {
                    towerItems.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}