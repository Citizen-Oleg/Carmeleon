using System;
using UnityEngine.EventSystems;

namespace Inventory
{
    /// <summary>
    /// Класс отвечающий за обработку нажатий на слот.
    /// </summary>
    public class SlotInteractionController
    {
        private bool HasItem => _currentSlot.HasItem;
        private ItemInSlot ItemInSlot => _currentSlot.ItemInSlot;
        
        private InventoryScreen _inventoryScreen;
        private Slot _currentSlot;
        public SlotInteractionController()
        {
            _inventoryScreen = LevelManager.InventoryScreen;
        }

        public void PointerEventDataHandler(PointerEventData eventData, Slot slot)
        {
            _currentSlot = slot;
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                LeftClick();
            }
            else
            {
                RightClick();
            }
        }
        
         private void LeftClick()
        {
            var currentItem = _inventoryScreen.CurrentItemInSlot;

            if (HasItem)
            {
                if (currentItem == null)
                {
                    _inventoryScreen.SetCurrentItem(ItemInSlot);
                    _currentSlot.ResetItem();
                    return;
                }

                if (!CheckSuitableId(currentItem)) return;
                if (!ItemInSlot.Item.HasStack) return;
                if (CheckAmountSuitable(currentItem)) return;
            }
           
            _inventoryScreen.ResetCurrentItem();
            if (currentItem != null)
            {
                _currentSlot.SetItem(currentItem);
            }
        }

        private bool CheckSuitableId(ItemInSlot currentItem)
        {
            if (currentItem.Item.ID != ItemInSlot.Item.ID)
            {
                _inventoryScreen.SetCurrentItem(ItemInSlot);
               _currentSlot.SetItem(currentItem);
                return false;
            }

            return true;
        }

        private bool CheckAmountSuitable(ItemInSlot currentItem)
        {
            var isAmountSuitable = currentItem.Amount + ItemInSlot.Amount <= ItemInSlot.Item.MAXStacks;
            if (isAmountSuitable)
            {
                _currentSlot.AddItem(currentItem, currentItem.Amount);
            }
            else
            {
                var freeUnits = ItemInSlot.Item.MAXStacks - ItemInSlot.Amount;
                _currentSlot.AddItem(currentItem, freeUnits);
            }
            
            _inventoryScreen.CheckCurrentItem();
            return true;
        }
        
        private void RightClick()
        {
            if (!_inventoryScreen.HasCurrentItem && !HasItem) return;
            
            if (!_inventoryScreen.HasCurrentItem && HasItem)
            {
                DivideItemSlot();
                return;
            }

            if (_inventoryScreen.HasCurrentItem)
            {
                DistributeItem();
            }
        }

        private void DistributeItem()
        {
            if (_inventoryScreen.HasCurrentItem && !HasItem)
            {
                _currentSlot.AddItem(_inventoryScreen.CurrentItemInSlot, 1);
                _inventoryScreen.CheckCurrentItem();
                return;
            }

            var hasItems = _inventoryScreen.HasCurrentItem && HasItem;
            var isAvailableStack = ItemInSlot.Item.HasStack && ItemInSlot.Amount < ItemInSlot.Item.MAXStacks;
            if (hasItems && _inventoryScreen.CurrentItemInSlot.Item.ID == ItemInSlot.Item.ID && isAvailableStack)
            {
                _currentSlot.AddItem(_inventoryScreen.CurrentItemInSlot, 1);
                _inventoryScreen.CheckCurrentItem();
            }
        }
        
        private void DivideItemSlot()
        {
            if (ItemInSlot.Amount == 1)
            {
                return;
            }
            
            var halfAmount = (int) Math.Ceiling((float) ItemInSlot.Amount / 2);

            ItemInSlot.Amount -= halfAmount;
            _inventoryScreen.SetCurrentItem(new ItemInSlot(ItemInSlot.Item, halfAmount));
            _currentSlot.RefreshUI();
        }
    }
}