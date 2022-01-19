using Inventory;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    public abstract class BestiaryItem<T> : ScriptableObject where T : Item 
    {
        public string Description => _description;
        public Sprite Art => _art;
        public Sprite SpriteCraftItem => _spriteCraftItem;
        public T Item => _item;

        [SerializeField]
        private string _description;
        [SerializeField]
        private Sprite _spriteCraftItem;
        [SerializeField]
        private Sprite _art;
        [SerializeField]
        private T _item;
    }
}