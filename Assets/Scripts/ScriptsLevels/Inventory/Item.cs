using Inventory.Craft;
using ResourceManager;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public int ID => _id;
        public virtual string Name => _name;
        public Sprite Sprite => _sprite;

        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _sprite;
    }
}
