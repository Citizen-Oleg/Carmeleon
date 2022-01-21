using System.Collections.Generic;
using System.Linq;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Inventory.Craft
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CraftRecipeItem", order = 2)]
    public class CraftRecipe : ScriptableObject
    {
        public int Amount => _amount;
        public InventoryItem[] ItemsOrder { get; private set; }
        
        [SerializeField]
        private int _amount;
        [SerializeField]
        private List<RowItemsRecipe> _rowItemsRecipes = new List<RowItemsRecipe>();
        
        public void Initialize()
        {
            var count = _rowItemsRecipes.Sum(rowItemsRecipe => rowItemsRecipe.Items.Count);
            
            ItemsOrder = new InventoryItem[count];
            var orderId = 0;
            foreach (var rowItemsRecipe in _rowItemsRecipes)
            {
                foreach (var item in rowItemsRecipe.Items)
                {
                    ItemsOrder[orderId++] = item;
                }
            }
        }
    }
}