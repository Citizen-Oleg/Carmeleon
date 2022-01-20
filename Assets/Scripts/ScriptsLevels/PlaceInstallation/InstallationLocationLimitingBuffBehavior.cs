using BuffSystem.SettingsBuff;
using Inventory;
using ScriptsLevels.Inventory;
using Towers;
using UnityEngine;

namespace PlaceInstallation
{
    public class InstallationLocationLimitingBuffBehavior : BehaviorPlaceInstallation
    {
        [SerializeField]
        private SettingsBuff<Tower> _towerBuff;
        [SerializeField]
        private DamageType _allowedDamateType;

        public override bool HasBusy(TowerItem towerItem)
        {
            if (towerItem != null)
            {
                return !base.HasBusy(towerItem) && towerItem.Tower.TowerCharacteristics.DamageType != _allowedDamateType;
            }
            
            return base.HasBusy(towerItem);
        }
        
        public override void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem)
        {
            base.InstallTower(itemInSlot, towerItem);
            _towerItem.Tower.TowerBuffController.AddBuff(_towerBuff);
        }

        public override ItemInSlot DestroyTower()
        {
            _towerItem.Tower.TowerBuffController.StopBuff(_towerBuff);
            return base.DestroyTower();
        }
    }
}