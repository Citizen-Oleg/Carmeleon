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
    }
}
