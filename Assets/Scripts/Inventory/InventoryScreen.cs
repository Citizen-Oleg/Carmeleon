using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryScreen : MonoBehaviour
    {
        public ItemInSlot CurrentItemInSlot => _currentItemInSlot;

        public bool HasCurrentItem => _currentItemInSlot != null;
        
        [SerializeField]
        private Image _curentItemImage;

        private ItemInSlot _currentItemInSlot;

        private void Start()
        {
            _curentItemImage.gameObject.SetActive(false);
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
            _currentItemInSlot = itemInSlot;
            _curentItemImage.sprite = _currentItemInSlot.Item.Sprite;
            _curentItemImage.gameObject.SetActive(true);
        }

        public void ResetCurrentItem()
        {
            _currentItemInSlot = null;
            _curentItemImage.gameObject.SetActive(false);
        }

        public void CheckCurrentItem()
        {
            if (HasCurrentItem && _currentItemInSlot.Amount < 1)
            {
                ResetCurrentItem();
            }
        }
    }
}
