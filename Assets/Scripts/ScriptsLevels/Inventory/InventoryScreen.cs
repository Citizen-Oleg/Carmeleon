using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryScreen : MonoBehaviour
    {
        public event Action<bool> OnChangingItem;

        public ItemInSlot CurrentItemInSlot => _currentItemInSlot;

        public bool HasCurrentItem => _currentItemInSlot != null;
        
        [SerializeField]
        private Image _curentItemImage;
        [SerializeField]
        private TextMeshProUGUI _textItemAmount;
        
        private ItemInSlot _currentItemInSlot;
        
        private void Start()
        {
            ResetCurrentItem();
        }

        private void Update()
        {
            if (HasCurrentItem)
            {
                _curentItemImage.transform.position = (Vector2) Input.mousePosition;
            }
        }

        public void SetCurrentItem(ItemInSlot itemInSlot)
        {
            OnChangingItem?.Invoke(true);
            _currentItemInSlot = itemInSlot;
            _curentItemImage.sprite = _currentItemInSlot.InventoryItem.Sprite;
            _curentItemImage.gameObject.SetActive(true);
            CheckCurrentItem();
        }

        public void ResetCurrentItem()
        {
            OnChangingItem?.Invoke(false);
            _currentItemInSlot = null;
            _curentItemImage.gameObject.SetActive(false);
            _textItemAmount.gameObject.SetActive(false);
        }

        public void CheckCurrentItem()
        {
            if (HasCurrentItem && _currentItemInSlot.Amount < 1)
            {
                ResetCurrentItem();
            }
            else
            {
                ResetAmountItem();
            }
        }

        private void ResetAmountItem()
        {
            if (_currentItemInSlot.Amount > 1)
            {
                _textItemAmount.gameObject.SetActive(true);
                _textItemAmount.text = _currentItemInSlot.Amount.ToString();
            }
            else
            {
                _textItemAmount.gameObject.SetActive(false);
            }
        }
    }
}
