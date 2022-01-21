using System.Collections.Generic;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Inventory.Craft
{
    public class ItemsManager : MonoBehaviour
    {
        public List<InventoryItem> ItemsWithCraft => _itemsWithCraft;

        [SerializeField]
        private List<InventoryItem> _itemsWithCraft;
        
        private void Awake()
        {
            foreach (var item in _itemsWithCraft)
            {
                if (item.HasRecipe)
                {
                    item.CraftRecipe.Initialize();
                }
            }
        }
    }
}