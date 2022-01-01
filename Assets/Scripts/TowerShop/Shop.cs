using Inventory;
using ResourceManager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TowerShop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private Transform _containerStandardTower;
        [SerializeField]
        private Transform _containerReagents;
        [SerializeField]
        private Transform _containerImprovedTowers;
        [SerializeField]
        private BuyButton _buyButtonPrefab;
        
        private InventoryManager _inventoryManager;
        private ResourceManagerLevel _resourceManagerLevel;
        private PlayerData _playerData;
        
        private void Awake()
        {
            _inventoryManager = LevelManager.InventoryManager;
            _resourceManagerLevel = LevelManager.ResourceManagerLevel;
            _playerData = GameManager.PlayerData;
            
            PlaceStandardTower();
            PlaceReagents();
            PlaceImprovedTowers();
        }

        private void PlaceStandardTower()
        {
            foreach (var towerItem in _playerData.StandardTowerLevel)
            {
                PlaceGoods(towerItem, _containerStandardTower, false);
            }
        }

        private void PlaceReagents()
        {
            for (int i = 0; i < _playerData.ReagentShopSize; i++)
            {
                var lenght = _playerData.ReagentsLevel.Count;
                var item = _playerData.ReagentsLevel[GetRandomIndex(lenght)];
                PlaceGoods(item, _containerReagents);
            }
        }

        private void PlaceImprovedTowers()
        {
            for (int i = 0; i < _playerData.ImprovedTowersSize; i++)
            {
                var lenght = _playerData.ImprovedLevelTowers.Count;
                var item = _playerData.ImprovedLevelTowers[GetRandomIndex(lenght)];
                PlaceGoods(item, _containerImprovedTowers);
            }
        }

        private void PlaceGoods<T>(T item, Transform container, bool isReplaceableItems = true) where T : Item
        {
            var buyButton = Instantiate(_buyButtonPrefab, container);
            buyButton.Initialize(BuyItem, item, isReplaceableItems);
        }
        
        private void BuyItem(Item item, BuyButton buyButton)
        {
            if (_resourceManagerLevel.HasEnough(item.Price.Type, item.Price.Amount) && _inventoryManager.AddItemToSlot(item))
            {
                _resourceManagerLevel.Pay(item.Price.Type, item.Price.Amount);
            }

            if (buyButton.IsReplaceableItems)
            {
                buyButton.SetNewItem(ReplaceItem(item.TypeItem));
            }
        }

        private Item ReplaceItem(TypeItem typeItem)
        {
            switch (typeItem)
            {
                case TypeItem.Reagent:
                    var lenght = _playerData.ReagentsLevel.Count;
                    return _playerData.ReagentsLevel[GetRandomIndex(lenght)];
                case TypeItem.Tower:
                    lenght = _playerData.ImprovedLevelTowers.Count;
                    return _playerData.ImprovedLevelTowers[GetRandomIndex(lenght)];
                default:
                    lenght = _playerData.StandardTowerLevel.Count;
                    return _playerData.StandardTowerLevel[GetRandomIndex(lenght)];
            }
        }

        private int GetRandomIndex(int length)
        {
            return Random.Range(0, length);
        }
    }
}