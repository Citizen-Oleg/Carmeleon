using Interface;
using Inventory;
using Level;
using ScriptsLevels.Level;
using UnityEngine;

namespace Loot
{
    public class Reagent : MonoBehaviour, IDropItem, IExplanationObject
    {
        public int ID => _id;
        public string Explanation => _name;
        public Transform Position => _positionExplanationUI;
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Transform _positionExplanationUI;
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