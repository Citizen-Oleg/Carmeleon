using Inventory;
using Inventory.Craft;
using ResourceManager;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InventoryItems/Item", order = 0)]
    public class InventoryItem : ScriptableObject
    {
        public Item Item
        {
            get => _item;
            set => _item = value;
        }
        public Resource Price => _price;
        public bool HasStack => _hasStack;
        public bool HasRecipe => CraftRecipe != null;
        public int MAXStacks => _maxStacks;
        public Sprite Sprite => Item.Sprite;
        public CraftRecipe CraftRecipe => _craftRecipe;

        [SerializeField]
        private Item _item;
        [SerializeField]
        private Resource _price;
        [SerializeField]
        private bool _hasStack;
        [SerializeField]
        private int _maxStacks;
        [SerializeField]
        private CraftRecipe _craftRecipe;
    }
}