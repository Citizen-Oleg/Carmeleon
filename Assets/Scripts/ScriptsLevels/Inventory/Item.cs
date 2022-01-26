using Inventory.Craft;
using ResourceManager;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Item", order = 0)]
    public abstract class Item : ScriptableObject
    {
        public int ID => _id;
        public virtual string Name { get; }
        public Sprite Sprite => _sprite;

        [SerializeField]
        private int _id;
        [SerializeField]
        private Sprite _sprite;
    }
}
