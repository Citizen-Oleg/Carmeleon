using System;
using Level;
using ScriptsLevels.Level;
using UnityEngine.EventSystems;

namespace Inventory
{
    /// <summary>
    /// Класс отвечающий за обработку нажатий на слот.
    /// От него требуется:
    /// При левом клике:
    ///     1. Клик по слоту с предметов без предмета в "руке" - взять предмет в руку
    ///      2. Клик по слоту с предметов с предметов в "руке":
    ///         2.1. Если предмет стакается и его стак не максимум то он прибавляет до максимум, а что не влезает остаётся в руке
    ///         2.2. Если предмет в руке имеет другой id с предметов в слоте то они меняются местами
    /// При правом клике:
    /// 1. Если предмет есть в руке и выбран слот с одинаковые предметом то отдаёт в этот слот 1 предмет из руки
    /// 2. Если нету предмета в руке но есть в слоте то от предмета берётся половина от стака с округлением в большую сторону
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
            if (!slot.IsOpen)
            {
                return;
            }
            
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

                if (!CheckSuitableId(currentItem) || !ItemInSlot.InventoryItem.HasStack || CheckAmountSuitable(currentItem))
                {
                    return;
                }
            }
           
            _inventoryScreen.ResetCurrentItem();
            if (currentItem != null)
            {
                _currentSlot.SetItem(currentItem);
            }
        }
         
         private void RightClick()
         {
             if (!_inventoryScreen.HasCurrentItem && !HasItem)
             {
                 return;
             }
            
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

        private bool CheckSuitableId(ItemInSlot currentItem)
        {
            if (currentItem.InventoryItem.Item.ID != ItemInSlot.InventoryItem.Item.ID)
            {
                _inventoryScreen.SetCurrentItem(ItemInSlot);
               _currentSlot.SetItem(currentItem);
                return false;
            }

            return true;
        }

        private bool CheckAmountSuitable(ItemInSlot currentItem)
        {
            var isAmountSuitable = currentItem.Amount + ItemInSlot.Amount <= ItemInSlot.InventoryItem.MAXStacks;
            if (isAmountSuitable)
            {
                _currentSlot.AddItem(currentItem, currentItem.Amount);
            }
            else
            {
                var freeUnits = ItemInSlot.InventoryItem.MAXStacks - ItemInSlot.Amount;
                _currentSlot.AddItem(currentItem, freeUnits);
            }
            
            _inventoryScreen.CheckCurrentItem();
            return true;
        }

        private void DistributeItem()
        {
            if (_inventoryScreen.HasCurrentItem && !HasItem)
            {
                _currentSlot.AddItem(_inventoryScreen.CurrentItemInSlot);
                _inventoryScreen.CheckCurrentItem();
                return;
            }

            var hasItems = _inventoryScreen.HasCurrentItem && HasItem;
            var isAvailableStack = ItemInSlot.InventoryItem.HasStack && ItemInSlot.Amount < ItemInSlot.InventoryItem.MAXStacks;
            if (hasItems && _inventoryScreen.CurrentItemInSlot.InventoryItem.Item.ID == ItemInSlot.InventoryItem.Item.ID 
                         && isAvailableStack)
            {
                _currentSlot.AddItem(_inventoryScreen.CurrentItemInSlot);
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
            _inventoryScreen.SetCurrentItem(new ItemInSlot(ItemInSlot.InventoryItem, halfAmount));
            _currentSlot.RefreshUI();
        }
    }
}