using ScriptsLevels.Inventory;
using UnityEngine;

namespace Inventory
{
    public class ItemInSlot
    {
        public InventoryItem InventoryItem { get; set; }
        public int Amount { get; set; }

        public ItemInSlot(InventoryItem inventoryItem, int amount = 1)
        {
            InventoryItem = inventoryItem;
            Amount = amount;
            InventoryItem = Object.Instantiate(InventoryItem);
        }
    }
}
