using Inventory;
using Level;
using ResourceManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerShop
{
    public class PlaceSellsItem : MonoBehaviour, IPointerClickHandler
    {
        [Range(0, 100)]
        [SerializeField]
        private float _moneyBackPercentage;
        
        private InventoryScreen _inventoryScreen;
        private ResourceManagerLevel _resourceManagerLevel;

        private void Awake()
        {
            _inventoryScreen = LevelManager.InventoryScreen;
            _resourceManagerLevel = LevelManager.ResourceManagerLevel;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && _inventoryScreen.HasCurrentItem)
            {
                var item = _inventoryScreen.CurrentItemInSlot.Item;
                var amount = item.Price.Amount * (_moneyBackPercentage / 100);
                _resourceManagerLevel.AddResource(item.Price.Type, (int) amount);
                _inventoryScreen.ResetCurrentItem();
            }
        }
    }
}