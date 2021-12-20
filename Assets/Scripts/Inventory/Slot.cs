using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class Slot : MonoBehaviour, IPointerClickHandler
    {
        private ItemInSlot ItemInSlot { get; set; }
        private bool HasItem => ItemInSlot != null;
        
        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;

        private void Start()
        {
            RefreshUI();
        }

        public void SetItem(ItemInSlot itemInSlot)
        {
            ItemInSlot = itemInSlot;
            RefreshUI();
        }

        private void AddItem(ItemInSlot itemInSlot, int amount)
        {
            itemInSlot.Amount -= amount;

            if (!HasItem)
            {
                SetItem(itemInSlot);
            }
            else
            {
                ItemInSlot.Amount += amount;
                RefreshUI();
            }
        }

        private void ResetItem()
        {
            ItemInSlot = null;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _itemImage.gameObject.SetActive(HasItem);
            _itemImage.sprite = ItemInSlot?.Item.Sprite;
            
            _itemAmount.gameObject.SetActive(HasItem && ItemInSlot.Amount > 1);
            _itemAmount.text = ItemInSlot?.Amount.ToString();
        }
        
        public void OnPointerClick(PointerEventData eventData)
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
            var inventoryScreen = LevelManager.InventoryScreen;
            var currentItem = inventoryScreen.CurrentItemInSlot;

            if (HasItem)
            {
                if (currentItem == null || !ItemInSlot.Item.Equals(currentItem.Item))
                {
                    inventoryScreen.SetCurrentItem(ItemInSlot);
                    ResetItem();
                }
                else
                {
                    AddItem(currentItem, currentItem.Amount);
                    inventoryScreen.CheckCurrentItem();
                    return;
                }
            }
            else
            {
                inventoryScreen.ResetCurrentItem();
            }

            if (currentItem != null)
            {
                SetItem(currentItem);
            }
        }

        private void RightClick()
        {
            var inventoryScreen = LevelManager.InventoryScreen;

            if (!inventoryScreen.HasCurrentItem)
            {
                return;
            }

            if (!HasItem || inventoryScreen.CurrentItemInSlot.Item == ItemInSlot.Item)
            {
                AddItem(inventoryScreen.CurrentItemInSlot, 1);
                inventoryScreen.CheckCurrentItem();
            }
        }
    }
}
