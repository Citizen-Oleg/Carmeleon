using System;
using System.Collections.Generic;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Inventory.Craft
{
    [Serializable]
    public class RowItemsRecipe
    {
        public List<InventoryItem> Items => _items;

        [SerializeField]
        private List<InventoryItem> _items = new List<InventoryItem>();
    }
}