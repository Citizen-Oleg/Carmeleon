using Interface;
using Inventory;
using Level;
using ScriptsLevels.Inventory;
using ScriptsLevels.Level;
using UnityEngine;

namespace Loot
{
    public class Reagent : MonoBehaviour, IDropItem, IExplanationObject
    {
        public int ID => _id;
        public string Name => _name;
        public Transform Position => _positionExplanationUI;
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Transform _positionExplanationUI;
        [SerializeField]
        private InventoryItem _item;

        private ReagentPool _reagentPool;
        private InventoryManager _inventoryManager;
        
        private void Awake()
        {
            _inventoryManager = LevelManager.InventoryManager;
            _reagentPool = LevelManager.ReagentPool;
        }

        public void PickUp()
        {
            if (_inventoryManager.AddItemToSlot(_item))
            {
                _reagentPool.ReleaseReagent(this);
            }
        }
    }
}