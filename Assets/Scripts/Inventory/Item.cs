using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        
        public bool HasStack => _hasStack;
        public int MAXStacks => _maxStacks;
        public Sprite Sprite => _sprite;
        
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private bool _hasStack;
        [SerializeField]
        private int _maxStacks;
        [SerializeField]
        private Sprite _sprite;
    }
}
