using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class Slot : MonoBehaviour, IPointerDownHandler
    {
        private bool HasItem => _itemInSlot != null;
        
        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;
        private ItemInSlot _itemInSlot;
       
        private InventoryScreen _inventoryScreen;

        private void Start()
        {
            _inventoryScreen = LevelManager.InventoryScreen;
            RefreshUI();
        }

        public void SetItem(ItemInSlot itemInSlot)
        {
            _itemInSlot = itemInSlot;
            RefreshUI();
        }

        private void AddItem(ItemInSlot itemInSlot, int amount)
        {
            itemInSlot.Amount -= amount;
            
            if (!HasItem)
            {
                SetItem(new ItemInSlot(itemInSlot.Item, amount));
            }
            else
            {
                _itemInSlot.Amount += amount;
                RefreshUI();
            }
        }

        private void ResetItem()
        {
            _itemInSlot = null;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _itemImage.gameObject.SetActive(HasItem);
            _itemImage.sprite = _itemInSlot?.Item.Sprite;
            
            _itemAmount.gameObject.SetActive(HasItem && _itemInSlot?.Amount > 1);
            _itemAmount.text = _itemInSlot?.Amount.ToString();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
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
                    _inventoryScreen.SetCurrentItem(_itemInSlot);
                    ResetItem();
                    return;
                }

                if (!CheckSuitableId(currentItem)) return;
                if (!_itemInSlot.Item.HasStack) return;
                if (CheckAmountSuitable(currentItem)) return;
            }
           
            _inventoryScreen.ResetCurrentItem();
            if (currentItem != null)
            {
                SetItem(currentItem);
            }
        }

        private bool CheckSuitableId(ItemInSlot currentItem)
        {
            if (currentItem.Item.ID != _itemInSlot.Item.ID)
            {
                _inventoryScreen.SetCurrentItem(_itemInSlot);
                SetItem(currentItem);
                return false;
            }

            return true;
        }

        private bool CheckAmountSuitable(ItemInSlot currentItem)
        {
            var isAmountSuitable = currentItem.Amount + _itemInSlot.Amount <= _itemInSlot.Item.MAXStacks; 
            switch (isAmountSuitable)
            {
                case true:
                    AddItem(currentItem, currentItem.Amount);
                    break;
                case false:
                {
                    var freeUnits = _itemInSlot.Item.MAXStacks - _itemInSlot.Amount;
                    AddItem(currentItem, freeUnits);
                    break;
                }
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
                AddItem(_inventoryScreen.CurrentItemInSlot, 1);
                _inventoryScreen.CheckCurrentItem();
                return;
            }

            var hasItems = _inventoryScreen.HasCurrentItem && HasItem;
            var isAvailableStack = _itemInSlot.Item.HasStack && _itemInSlot.Amount < _itemInSlot.Item.MAXStacks;
            if (hasItems && _inventoryScreen.CurrentItemInSlot.Item.ID == _itemInSlot.Item.ID && isAvailableStack)
            {
                AddItem(_inventoryScreen.CurrentItemInSlot, 1);
                _inventoryScreen.CheckCurrentItem();
            }
        }
        
        private void DivideItemSlot()
        {
            if (_itemInSlot.Amount == 1)
            {
                return;
            }
            
            var halfAmount = (int) Math.Ceiling((float) _itemInSlot.Amount / 2);

            _itemInSlot.Amount -= halfAmount;
            _inventoryScreen.SetCurrentItem(new ItemInSlot(_itemInSlot.Item, halfAmount));
            RefreshUI();
        }
    }
}
