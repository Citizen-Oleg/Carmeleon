using BuffSystem.SettingsBuff;
using Inventory;
using PlaceInstallation;
using UnityEngine;

namespace Towers
{
    public class BuffBehaviorPlaceInstallationTower : BehaviorPlaceInstallation
    {
        [SerializeField]
        private SettingsBuff<Tower> _towerBuff;

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