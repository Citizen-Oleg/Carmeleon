﻿using Interface;
using Inventory;
using Level;
using PlaceInstallation;
using ScriptsLevels.Inventory;
using ScriptsLevels.Level;
using Towers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace DragController
{
    /// <summary>
    /// Класс отвечающий за перемещение башен из инвентаря на поле и обратно.
    /// </summary>
    public class TowerDragController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
    {
        [SerializeField]
        private TowerItemManager _towerItemManager;
        [SerializeField]
        private InventoryScreen _inventoryScreen;
        [SerializeField]
        private LayerMask _layerPlaceInstallation;
        
        private ItemInSlot _currentItemInSlot;
        private TowerItem _towerItem;
        
        private void Update()
        {
            if (_currentItemInSlot != null)
            {
                var position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _towerItem.GhostTower.gameObject.SetActive(true);
                _towerItem.GhostTower.transform.position = position;
            }
            
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                LeftClick();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_inventoryScreen.HasCurrentItem && _inventoryScreen.CurrentItemInSlot.InventoryItem.Item is TowerItem towerItem)
            {
                _currentItemInSlot = _inventoryScreen.CurrentItemInSlot;
                _inventoryScreen.ResetCurrentItem();
                _towerItem = _towerItemManager.GetInitializedTowerItem(towerItem);
                _currentItemInSlot.InventoryItem.Item = _towerItem;
            } 
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_currentItemInSlot != null)
            {
                _inventoryScreen.SetCurrentItem(_currentItemInSlot);
                ResetCurrentItem();
            }
        }
        
        private void LeftClick()
        {
            if (_inventoryScreen.HasCurrentItem)
            {
                return;
            }
            
            var target = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHit = Physics2D.Raycast(target.origin, target.direction, 100f , _layerPlaceInstallation);

            if (raycastHit.collider == null)
            {
                return;
            }

            if (_currentItemInSlot != null)
            {
                SetTowerByPlace(raycastHit);
            }
            else
            {
                GetTowerFromPlace(raycastHit);
            }
        }

        private void SetTowerByPlace(RaycastHit2D raycastHit2D)
        {
            if (!raycastHit2D.collider.TryGetComponent(out PlaceInstallationTower placeInstallationTower))
            {
                return;
            }
            
            if (placeInstallationTower.HasFreePlaceInstallation(_towerItem))
            {
                InstallTower(placeInstallationTower);
                ResetCurrentItem();
            }
        }

        private void GetTowerFromPlace(RaycastHit2D raycastHit2D)
        {
            if (!raycastHit2D.collider.TryGetComponent(out PlaceInstallationTower placeInstallationTower))
            {
                return;
            }

            if (placeInstallationTower.IsAvailableForDemolition(_towerItem))
            {
                _currentItemInSlot = placeInstallationTower.DestroyTower();
                _towerItem = (TowerItem) _currentItemInSlot.InventoryItem.Item;
            }
        }

        private void InstallTower(PlaceInstallationTower placeInstallationTower)
        {
            _towerItem.GhostTower.gameObject.SetActive(false);
            placeInstallationTower.InstallTower(_currentItemInSlot, _towerItem);
        }

        private void ResetCurrentItem()
        {
            _towerItem.GhostTower.gameObject.SetActive(false);
            _towerItem = null;
            _currentItemInSlot = null;
        }
    }
}