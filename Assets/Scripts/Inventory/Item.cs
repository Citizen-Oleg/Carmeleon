using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public Sprite Sprite => _sprite;

        [SerializeField]
        private Sprite _sprite;
    }
}
