using System;
using Inventory;
using Level;
using ResourceManager;
using ScriptsLevels.Level;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerShop
{
    public class PlaceSellsItem : MonoBehaviour, IPointerClickHandler
    {
        [Range(0, 100)]
        [SerializeField]
        private float _moneyBackPercentage;
        
        private InventoryScreen _inventoryScreen;
        private ResourceManagerLevel _resourceManagerLevel;

        private void Awake()
        {
            _inventoryScreen = LevelManager.InventoryScreen;
            _resourceManagerLevel = LevelManager.ResourceManagerLevel;
            _inventoryScreen.OnChangingItem += Display;
            gameObject.SetActive(false);
        }

        private void Display(bool hasMapping)
        {
            gameObject.SetActive(hasMapping);
        }
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && _inventoryScreen.HasCurrentItem)
            {
                var itemInSlot = _inventoryScreen.CurrentItemInSlot;
                var item = itemInSlot.InventoryItem;

                float amount = item.HasStack && itemInSlot.Amount != 0
                    ? item.Price.Amount * itemInSlot.Amount
                    : item.Price.Amount;
                
                amount *= _moneyBackPercentage / 100;
                _resourceManagerLevel.AddResource(item.Price.Type, (int) amount);
                _inventoryScreen.ResetCurrentItem();
            }
        }

        private void OnDestroy()
        {
            _inventoryScreen.OnChangingItem -= Display;
        }
    }
}