using System.Collections.Generic;
using System.Linq;
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
        private List<Slot> _filledSlotsStacks = new List<Slot>();

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

        public bool AddItemToSlot(Item item)
        {
            if (item.HasStack && AddItemToFilledSlot(item))
            {
                return true;
            }

            var freeSlot = GetFreeSlot();
            if (freeSlot != null)
            {
                freeSlot.SetItem(new ItemInSlot(item));
                return true;
            }

            return false;
        }
 
        private Slot GetFreeSlot()
        {
            return _slots.FirstOrDefault(slot => !slot.HasItem);
        }


        private bool AddItemToFilledSlot(Item item)
        {
            foreach (var slot in _filledSlotsStacks)
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
