using Inventory.Craft;
using ResourceManager;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public int ID => _id;
        public TypeItem TypeItem => _typeItem;
        public Resource Price => _price;
        public bool HasStack => _hasStack;
        public bool HasRecipe => CraftRecipe != null;
        public int MAXStacks => _maxStacks;
        public Sprite Sprite => _sprite;
        public CraftRecipe CraftRecipe => _craftRecipe;
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private TypeItem _typeItem;
        [SerializeField]
        private Resource _price;
        [SerializeField]
        private bool _hasStack;
        [SerializeField]
        private int _maxStacks;
        [SerializeField]
        private Sprite _sprite;
        [SerializeField]
        private CraftRecipe _craftRecipe;
    }
}
