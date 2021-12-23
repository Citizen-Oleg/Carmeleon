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
        private TextMeshProUGUI _itemPrice;

        private Action<Item, BuyButton> _callback;
        private bool _isReplaceableItems;
        private Item _item;

        public void Initialize(Action<Item, BuyButton> callback, Item item, bool isReplaceableItems = true)
        {
            _callback = callback;
            _item = item;
            _isReplaceableItems = isReplaceableItems;

            _itemSprite.sprite = _item.Sprite;
            _itemPrice.text = _item.Price.Amount.ToString();
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
            _callback?.Invoke(_item, this);
        }
    }
}