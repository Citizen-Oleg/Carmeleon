using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using View;

namespace Inventory
{
    /// <summary>
    /// Класс, хранящий в себе предмет.
    /// </summary>
    public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<Slot> OnChange;
        public bool IsOpen => _isOpen;
        public bool HasItem => _itemInSlot != null;
        public bool HasFreePlaces => HasItem && _itemInSlot.Item.MAXStacks != _itemInSlot.Amount;
        public ItemInSlot ItemInSlot => _itemInSlot;

        [SerializeField]
        private Image _itemImage;
        [SerializeField]
        private Image _slotImage;
        [SerializeField]
        private Sprite _closingSprite;
        [SerializeField]
        private TextMeshProUGUI _itemAmount;
        [SerializeField]
        private ViewExplanation _viewExplanation;

        private bool _isOpen;
        private ItemInSlot _itemInSlot;
        private SlotInteractionController _slotInteractionController;

        private void Start()
        {
            RefreshUI();
        }
        
        public void Initialize(SlotInteractionController slotInteractionController, bool isOpen)
        {
            _slotInteractionController = slotInteractionController;
            _isOpen = isOpen;

            if (!isOpen)
            {
                _slotImage.sprite = _closingSprite;
            }
        }
        
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _slotInteractionController.PointerEventDataHandler(eventData, this);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (HasItem)
            {
                _viewExplanation.Show(_itemInSlot.Item.Name);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _viewExplanation.Close();
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
