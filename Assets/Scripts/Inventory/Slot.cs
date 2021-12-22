using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory
{
    public class Slot : MonoBehaviour, IPointerDownHandler
    {
        public event Action<Slot> OnChange;
        public bool HasItem => _itemInSlot != null;
        public bool HasFreePlaces => HasItem && _itemInSlot.Item.MAXStacks != _itemInSlot.Amount;
        public ItemInSlot ItemInSlot => _itemInSlot;

        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;

        private ItemInSlot _itemInSlot;
        private SlotInteractionController _slotInteractionController;

        private void Start()
        {
            RefreshUI();
        }
        
        public void Initialize(SlotInteractionController slotInteractionController)
        {
            _slotInteractionController = slotInteractionController;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _slotInteractionController.PointerEventDataHandler(eventData, this);
        }

        public void SetItem(ItemInSlot itemInSlot)
        {
            _itemInSlot = itemInSlot;
            RefreshUI();
        }

        public void AddItem(ItemInSlot itemInSlot, int amount = 1)
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

        public void ResetItem()
        {
            _itemInSlot = null;
            RefreshUI();
            OnChange?.Invoke(this);
        }

        public void RefreshUI()
        {
            _itemImage.gameObject.SetActive(HasItem);
            _itemImage.sprite = _itemInSlot?.Item.Sprite;

            _itemAmount.gameObject.SetActive(HasItem && _itemInSlot?.Amount > 1);
            _itemAmount.text = _itemInSlot?.Amount.ToString();
        }
    }
}
