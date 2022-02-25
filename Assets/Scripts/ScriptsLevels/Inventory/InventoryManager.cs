using System;
using System.Collections.Generic;
using System.Linq;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private InventoryScreen _inventoryScreen;
        [Range(0, 12)]
        [SerializeField]
        private int _countSlots = 12;
        [SerializeField]
        private Slot _prefabSlot;
        [SerializeField]
        private Transform _containerSlots;

        private SlotInteractionController _slotInteractionController;
        private Slot[] _slots;

        private void Awake()
        {
            var playerData = GameManager.PlayerData;
            _slotInteractionController = new SlotInteractionController(_inventoryScreen);
            _slots = new Slot[_countSlots];

            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i] = Instantiate(_prefabSlot, _containerSlots, false);
                _slots[i].Initialize(_slotInteractionController, i < playerData.InventorySize);
            }
        }

        public bool AddItemToSlot(InventoryItem inventoryItem)
        {
            if (inventoryItem.HasStack && AddItemToFilledSlot(inventoryItem))
            {
                return true;
            }

            var freeSlot = GetFreeSlot();
            if (freeSlot != null)
            {
                freeSlot.SetItem(new ItemInSlot(inventoryItem));
                return true;
            }

            return false;
        }
 
        private Slot GetFreeSlot()
        {
            return _slots.FirstOrDefault(slot => !slot.HasItem && slot.IsOpen);
        }

        private bool AddItemToFilledSlot(InventoryItem inventoryItem)
        {
            foreach (var slot in _slots)
            {
                if (slot.HasItem && slot.ItemInSlot.InventoryItem.Item.ID == inventoryItem.Item.ID && slot.HasFreePlaces)
                {
                    slot.AddItem(new ItemInSlot(inventoryItem));
                    return true;
                }
            }

            return false;
        }
    }
}
