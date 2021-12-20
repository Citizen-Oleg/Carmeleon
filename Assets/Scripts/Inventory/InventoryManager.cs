using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private int _countSlots;
        [SerializeField]
        private Slot _prefabSlot;
        [SerializeField]
        private Transform _containerSlots;

        private Slot[] _slots;

        private void Awake()
        {
            _slots = new Slot[_countSlots];

            for (int i = 0; i < _countSlots; i++)
            {
                _slots[i] = Instantiate(_prefabSlot, _containerSlots, false);
            }
        }

        public void AddItemToSlot(ItemInSlot itemInSlot)
        {
            _slots[0].SetItem(itemInSlot);
        }
    }
}
