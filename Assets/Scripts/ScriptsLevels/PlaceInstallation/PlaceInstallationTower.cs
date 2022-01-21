﻿using System;
using Interface;
using Inventory;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace PlaceInstallation
{
    [RequireComponent(typeof(IBehaviorPlaceInstallation))]
    [RequireComponent(typeof(Collider2D))]
    public class PlaceInstallationTower : MonoBehaviour
    {
        public event Action<PlaceInstallationTower> OnDestroyTower;

        public IBehaviorPlaceInstallation BehaviorPlaceInstallation => _behaviorPlaceInstallation;

        private IBehaviorPlaceInstallation _behaviorPlaceInstallation;
        
        private void Awake()
        {
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
            _behaviorPlaceInstallation.InstallTower(itemInSlot, towerItem);
        }

        public ItemInSlot DestroyTower()
        {
            OnDestroyTower?.Invoke(this);
            return _behaviorPlaceInstallation.DestroyTower();
        }
    }
}