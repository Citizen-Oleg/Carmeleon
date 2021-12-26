using System;
using UnityEngine.EventSystems;

namespace Inventory.Craft
{
    public class CraftSlot : Slot
    {
        private CraftController _craftController;
        
        private void Awake()
        {
            _craftController = LevelManager.CraftController;
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _craftController.CheckCraft();
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