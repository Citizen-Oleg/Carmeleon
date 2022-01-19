using Inventory;
using Level;
using ResourceManager;
using ScriptsLevels.Level;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TowerShop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private int _sizeStandatdTower = 4;
        [SerializeField]
        private Transform _containerStandardTower;
        [Space]
        [SerializeField]
        private int _sizeReagents = 4;
        [SerializeField]
        private Transform _containerReagents;
        [Space]
        [SerializeField]
        private int _sizeImprovedTowers = 4;
        [SerializeField]
        private Transform _containerImprovedTowers;
        [SerializeField]
        private BuyButton _buyButtonPrefab;
        
        private InventoryManager _inventoryManager;
        private ResourceManagerLevel _resourceManagerLevel;
        private PlayerData _playerData;
        
        private void Start()
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
            for (int i = 0; i < _sizeStandatdTower; i++)
            {
                if (i >= _playerData.StandardTowerLevel.Count)
                {
                    PlaceGoods<Item>(null, _containerStandardTower, false);
                }
                else
                {
                    PlaceGoods(_playerData.StandardTowerLevel[i], _containerStandardTower, true, false);
                }
            }
        }

        private void PlaceReagents()
        {
            for (int i = 0; i < _sizeReagents; i++)
            {
                if (i >= _playerData.ReagentShopSize)
                {
                    PlaceGoods<Item>(null, _containerReagents, false);
                }
                else
                {
                    var lenght = _playerData.ReagentsLevel.Count;
                    var item = _playerData.ReagentsLevel[GetRandomIndex(lenght)];
                    PlaceGoods(item, _containerReagents, true);
                }
            }
        }

        private void PlaceImprovedTowers()
        {
            for (int i = 0; i < _sizeImprovedTowers; i++)
            {
                if (i >= _playerData.ImprovedTowersSize)
                {
                    PlaceGoods<Item>(null, _containerImprovedTowers, false);
                }   
                else
                {
                    var lenght = _playerData.ImprovedLevelTowers.Count;
                    var item = _playerData.ImprovedLevelTowers[GetRandomIndex(lenght)];
                    PlaceGoods(item, _containerImprovedTowers, true);
                }
            }
        }

        private void PlaceGoods<T>(T item, Transform container, bool isOpen, bool isReplaceableItems = true) where T : Item
        {
            var buyButton = Instantiate(_buyButtonPrefab, container);
            buyButton.Initialize(BuyItem, isOpen, item, isReplaceableItems);
        }
        
        private void BuyItem(Item item, BuyButton buyButton)
        {
            var discount = item.Price.Amount * (GameManager.PlayerData.StoreDiscount / 100);
            var price = (int) (item.Price.Amount - discount);
            if (_resourceManagerLevel.HasEnough(item.Price.Type, price) && _inventoryManager.AddItemToSlot(item))
            {
                _resourceManagerLevel.Pay(item.Price.Type, price);
                
                if (buyButton.IsReplaceableItems)
                {
                    buyButton.SetNewItem(ReplaceItem(item.TypeItem));
                }
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