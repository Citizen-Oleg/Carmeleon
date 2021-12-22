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

        private SlotInteractionController _slotInteractionController;
        private Slot[] _slots;

        private void Awake()
        {
            _slotInteractionController = new SlotInteractionController();
            _slots = new Slot[_countSlots];

            for (int i = 0; i < _countSlots; i++)
            {
                _slots[i] = Instantiate(_prefabSlot, _containerSlots, false);
                _slots[i].Initialize(_slotInteractionController);
            }
        }

        public void AddItemToSlot(Item item)
        {
            if (item.HasStack && HasSameItem(item))
            {
                return;
            }

            foreach (var slot in _slots)
            {
                if (!slot.HasItem)
                {
                    slot.SetItem(new ItemInSlot(item));
                    break;
                }
            }
        }

        private bool HasSameItem(Item item)
        {
            foreach (var slot in _slots)
            {
                if (slot.HasItem && slot.ItemInSlot.Item.ID == item.ID && slot.HasFreePlaces)
                {
                    slot.AddItem(new ItemInSlot(item));
                    return true;
                }
            }

            return false;
        }
    }
}
