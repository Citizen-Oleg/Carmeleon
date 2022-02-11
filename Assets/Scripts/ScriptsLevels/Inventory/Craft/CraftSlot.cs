using System;
using Level;
using ScriptsLevels.Level;
using UnityEngine.EventSystems;

namespace Inventory.Craft
{
    public class CraftSlot : Slot
    {
        public event Action OnCheckCraft;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            OnCheckCraft?.Invoke();
        }

        public void DecreaseItemAmount(int amount)
        {
            ItemInSlot.Amount -= amount;

            if (ItemInSlot.Amount < 1)
            {
                ResetItem();
            }
        
            RefreshUI();
        }
    }
}