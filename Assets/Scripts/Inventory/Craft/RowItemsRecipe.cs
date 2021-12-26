using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Craft
{
    [Serializable]
    public class RowItemsRecipe
    {
        public List<Item> Items => _items;

        [SerializeField]
        private List<Item> _items = new List<Item>();
    }
}