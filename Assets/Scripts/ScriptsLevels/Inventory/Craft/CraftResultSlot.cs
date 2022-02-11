using System;
using Level;
using ScriptsLevels.Level;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Craft
{
    public class CraftResultSlot : Slot
    {
        [SerializeField]
        private InventoryScreen _inventoryScreen;
        [SerializeField]
        private CraftController _craftController;
        
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