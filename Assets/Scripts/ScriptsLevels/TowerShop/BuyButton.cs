using System;
using Inventory;
using JetBrains.Annotations;
using ScriptsLevels.ExplanationObject;
using ScriptsLevels.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

namespace TowerShop
{
    public class BuyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool IsReplaceableItems => _isReplaceableItems;

        [SerializeField]
        private Image _itemSprite;
        [SerializeField]
        private Image _imageButton;
        [SerializeField]
        private Sprite _closingSprite;
        [SerializeField]
        private TextMeshProUGUI _itemPrice;
        [SerializeField]
        private ViewExplanation _viewExplanation;

        private Action<InventoryItem, BuyButton> _callback;
        private bool _isReplaceableItems;
        private InventoryItem _item;
        private bool _isOpen;

        public void Initialize(Action<InventoryItem, BuyButton> callback, bool isOpen, InventoryItem item, bool isReplaceableItems = true)
        {
            _isOpen = isOpen;

            if (_isOpen)
            {
                _callback = callback;
                _item = item;
                _isReplaceableItems = isReplaceableItems;
                RefreshUI();
            }
            else
            {
                _itemPrice.gameObject.SetActive(isOpen);
                _itemSprite.gameObject.SetActive(isOpen);
                _imageButton.sprite = _closingSprite;
            }
        }

        public void SetNewItem(InventoryItem inventoryItem)
        {
            _item = inventoryItem;
            RefreshUI();
        }

        private void RefreshUI()
        {
            _itemSprite.sprite = _item.Sprite;
            var discount = _item.Price.Amount * (GameManager.PlayerData.StoreDiscount / 100);
            var price = (int) (_item.Price.Amount - discount);
            _itemPrice.text = price.ToString();
        }

        [UsedImplicitly]
        public void BuyItem()
        {
            if (_isOpen)
            {
                _callback?.Invoke(_item, this);
                _viewExplanation.Show(_item.Item.Name);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isOpen)
            {
                _viewExplanation.Show(_item.Item.Name);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isOpen)
            {
                _viewExplanation.Close();
            }
        }
    }
}