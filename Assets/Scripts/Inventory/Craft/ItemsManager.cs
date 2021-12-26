using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Craft
{
    public class ItemsManager : MonoBehaviour
    {
        public List<Item> ItemsWithCraft => _itemsWithCraft;

        [SerializeField]
        private List<Item> _itemsWithCraft;
        
        private void Awake()
        {
            _itemsWithCraft.ForEach(item => item?.CraftRecipe.Initialize());
        }
    }
}