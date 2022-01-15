using System;
using Inventory;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace TowerShop
{
    public class BuyButton : MonoBehaviour
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

        private Action<Item, BuyButton> _callback;
        private bool _isReplaceableItems;
        private Item _item;
        private bool _isOpen;

        public void Initialize(Action<Item, BuyButton> callback, bool isOpen, Item item, bool isReplaceableItems = true)
        {
            _isOpen = isOpen;

            if (_isOpen)
            {
                _callback = callback;
                _item = item;
                _isReplaceableItems = isReplaceableItems;

                _itemSprite.sprite = _item.Sprite;
                _itemPrice.text = _item.Price.Amount.ToString();
            }
            else
            {
                _itemPrice.gameObject.SetActive(isOpen);
                _itemSprite.gameObject.SetActive(isOpen);
                _imageButton.sprite = _closingSprite;
            }
        }

        public void SetNewItem(Item item)
        {
            _item = item;
            _itemSprite.sprite = _item.Sprite;
            _itemPrice.text = _item.Price.Amount.ToString();
        }

        [UsedImplicitly]
        public void BuyItem()
        {
            if (_isOpen)
            {
                _callback?.Invoke(_item, this);
            }
        }
    }
}