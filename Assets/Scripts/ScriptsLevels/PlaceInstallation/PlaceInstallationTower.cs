using System;
using Interface;
using Inventory;
using ScriptsLevels.Inventory;
using ScriptsLevels.Level;
using Towers;
using UnityEngine;

namespace PlaceInstallation
{
    [RequireComponent(typeof(IBehaviorPlaceInstallation))]
    [RequireComponent(typeof(Collider2D))]
    public class PlaceInstallationTower : MonoBehaviour
    {
        public event Action<PlaceInstallationTower> OnDestroyTower;
        
        
        public IBehaviorPlaceInstallation BehaviorPlaceInstallation => _behaviorPlaceInstallation;
        public Transform PositionView => _positionView;

        [SerializeField]
        private Transform _positionView;

        private ManagerTower _managerTower;
        private IBehaviorPlaceInstallation _behaviorPlaceInstallation;
        
        private void Awake()
        {
            _managerTower = LevelManager.ManagerTower;
            _behaviorPlaceInstallation = GetComponent<IBehaviorPlaceInstallation>();
        }

        public bool HasFreePlaceInstallation(TowerItem towerItem)
        {
            var hasBusy = _behaviorPlaceInstallation.HasBusy(towerItem);
            var hasBlock = _behaviorPlaceInstallation.HasBlock;
            return !hasBusy && !hasBlock;
        }

        public bool IsAvailableForDemolition(TowerItem towerItem)
        {
            return _behaviorPlaceInstallation.HasBusy(towerItem);
        }

        public void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem)
        {
            _managerTower.AddTower(towerItem.Tower);
            _behaviorPlaceInstallation.InstallTower(itemInSlot, towerItem);
        }

        public ItemInSlot DestroyTower()
        {
            OnDestroyTower?.Invoke(this);
            var itemInSlot = _behaviorPlaceInstallation.DestroyTower();
            var tower = (TowerItem) itemInSlot.InventoryItem.Item;
            _managerTower.RemoveTower(tower.Tower);
            return itemInSlot;
        }
    }
}