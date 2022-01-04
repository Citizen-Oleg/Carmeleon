using System;
using Level;
using UnityEngine.EventSystems;

namespace Inventory.Craft
{
    public class CraftResultSlot : Slot
    {
        private InventoryScreen _inventoryScreen;
        private CraftController _craftController;
        
        private void Awake()
        {
            _inventoryScreen = LevelManager.InventoryScreen;
            _craftController = LevelManager.CraftController;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (_inventoryScreen.HasCurrentItem || !_craftController.HasResultItem || !HasItem)
                {
                    return;
                }
        
                _inventoryScreen.SetCurrentItem(ItemInSlot);
                ResetItem();
                _craftController.CraftItem();
            }
        }
    }
}