using System.Linq;
using UnityEngine;

namespace Inventory.Craft
{
    /// <summary>
    /// Класс отвечающий за крафт предметов.
    /// </summary>
    public class CraftController : MonoBehaviour
    {
        private const int TALKING_RESOURCES_FOR_CRAFTING = 1;
        private const int CRAFTING_GRID_SIZE = 3;
        
        private CraftSlot[,] CraftTable { get; set; }
        public bool HasResultItem => _resultSlot != null;

        [SerializeField]
        private InventoryScreen _inventoryScreen;
        [SerializeField]
        private ItemsManager _itemsManager;
        [SerializeField]
        private CraftSlot _craftSlotPrefab;
        [SerializeField]
        private Transform _craftGrid;
        [SerializeField]
        private CraftResultSlot _resultSlot;
        
        private SlotInteractionController _slotInteractionController;
        
        public void Awake()
        {
            CraftTable = new CraftSlot[CRAFTING_GRID_SIZE, CRAFTING_GRID_SIZE];
            _slotInteractionController = new SlotInteractionController(_inventoryScreen);
            CreateSlotsPrefabs();
        }

        private void CreateSlotsPrefabs()
        {
            for (int i = 0; i < CraftTable.GetLength(0); i++)
            {
                for (int j = 0; j < CraftTable.GetLength(1); j++)
                {
                    CraftTable[i, j] = Instantiate(_craftSlotPrefab, _craftGrid, false);
                    CraftTable[i, j].Initialize(_slotInteractionController, true);
                    CraftTable[i, j].OnCheckCraft += CheckCraft;
                }
            }
        }

        public void CheckCraft()
        {
            var currentRecipeW = 0;
            var currentRecipeH = 0;
            var currentRecipeWStartIndex = -1;
            var currentRecipeHStartIndex = -1;

            for (int i = 0; i < CraftTable.GetLength(0); i++)
            {
                for (int j = 0; j < CraftTable.GetLength(1); j++)
                {
                    if (CraftTable[i, j].HasItem)
                    {
                        if (currentRecipeHStartIndex == -1)
                        {
                            currentRecipeHStartIndex = i;
                        }
                        currentRecipeH++;
                        break;
                    }
                }
            }

            for (int i = 0; i < CraftTable.GetLength(1); i++)
            {
                for (int j = 0; j < CraftTable.GetLength(0); j++)
                {
                    if (CraftTable[j, i].HasItem)
                    {
                        if (currentRecipeWStartIndex == -1)
                        {
                            currentRecipeWStartIndex = i;
                        }

                        currentRecipeW++;
                        break;  
                    }
                }
            }
            
            var craftOrder = new Item[currentRecipeH * currentRecipeW];

            var orderIndex = 0;
            
            for (int i = currentRecipeHStartIndex; i < currentRecipeHStartIndex + currentRecipeH; i++)
            {
                for (int j = currentRecipeWStartIndex; j < currentRecipeWStartIndex + currentRecipeW; j++)
                {
                    craftOrder[orderIndex++] = CraftTable[i,j].ItemInSlot?.InventoryItem.Item;
                }
            }
            ItemInSlot craftItem = null;

            foreach (var item in _itemsManager.ItemsWithCraft)
            {
                if (item.HasRecipe && item.CraftRecipe.ItemsOrder.SequenceEqual(craftOrder))
                {
                    craftItem = new ItemInSlot(item, item.CraftRecipe.Amount);
                    break;
                }
            }

            if (craftItem != null)
            {
                _resultSlot.SetItem(craftItem);   
            }
            else
            {
                _resultSlot.ResetItem();
            }
        }

        public void CraftItem()
        {
            for (int i = 0; i < CraftTable.GetLength(0); i++)
            {
                for (int j = 0; j < CraftTable.GetLength(1); j++)
                {
                    if (CraftTable[i, j].ItemInSlot != null)
                    {
                        CraftTable[i, j].DecreaseItemAmount(TALKING_RESOURCES_FOR_CRAFTING);
                    }
                }
            }
            
            CheckCraft();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < CraftTable.GetLength(0); i++)
            {
                for (int j = 0; j < CraftTable.GetLength(1); j++)
                {
                    CraftTable[i, j].OnCheckCraft -= CheckCraft;
                }
            }
        }
    }
}