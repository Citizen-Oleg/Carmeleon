using Inventory;
using PlaceInstallation;
using UnityEngine;

namespace Towers
{
    public class BehaviorRestrictiveInstallationLocation : BehaviorPlaceInstallation
    {
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
    }
}