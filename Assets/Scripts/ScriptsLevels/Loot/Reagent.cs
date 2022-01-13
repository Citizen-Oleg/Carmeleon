using Interface;
using Inventory;
using Level;
using ScriptsLevels.Level;
using UnityEngine;

namespace Loot
{
    public class Reagent : MonoBehaviour, IDropItem
    {
        public int ID => _id;

        [SerializeField]
        private int _id;
        [SerializeField]
        private Item _item;

        private ReagentPool _reagentPool;
        private InventoryManager _inventoryManager;
        
        private void Awake()
        {
            _inventoryManager = LevelManager.InventoryManager;
            _reagentPool = LevelManager.ReagentPool;
        }

        public void PickUp()
        {
            _reagentPool.ReleaseReagent(this);
            _inventoryManager.AddItemToSlot(_item);
        }
    }
}