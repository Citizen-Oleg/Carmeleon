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
        public Item[,] ItemsOrder { get; private set; }
        
        [SerializeField]
        private int _amount = 1;
        [SerializeField]
        private List<RowItemsRecipe> _rowItemsRecipes = new List<RowItemsRecipe>();
        
        public void Initialize()
        {
            ItemsOrder = new Item[_rowItemsRecipes.Count, _rowItemsRecipes[0].Items.Count];

            for (int i = 0; i < _rowItemsRecipes.Count; i++)
            {
                for (int j = 0; j < _rowItemsRecipes[i].Items.Count; j++)
                {
                    ItemsOrder[i, j] = _rowItemsRecipes[i].Items[j]?.Item;
                }
            }
        }
    }
}