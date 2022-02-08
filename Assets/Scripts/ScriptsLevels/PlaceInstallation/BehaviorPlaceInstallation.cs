using Interface;
using Inventory;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace PlaceInstallation
{
    public class BehaviorPlaceInstallation : MonoBehaviour, IBehaviorPlaceInstallation
    {
        public float BlockDuration => _blockDuration;
        public bool HasBlock => _blockTime > Time.time;

        [SerializeField]
        private Transform _installationPosition;
        [SerializeField]
        private GameObject _flag;
        [SerializeField]
        private float _blockDuration;
        
        private ItemInSlot _itemInSlot;
        protected TowerItem _towerItem;

        private float _blockTime;

        public virtual bool HasBusy(TowerItem towerItem)
        {
            return _itemInSlot != null && _towerItem != null && _towerItem.Tower.TowerCharacteristics.CanAttack;
        }
        
        public virtual void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem)
        {
            _itemInSlot = itemInSlot;
            _towerItem = towerItem;
            
            _flag.SetActive(false);
            _towerItem.Tower.transform.position = _installationPosition.position;
            _towerItem.Tower.gameObject.SetActive(true);
        }

        public virtual ItemInSlot DestroyTower()
        {
            _blockTime = Time.time + _blockDuration;
            
            _towerItem.Tower.gameObject.SetActive(false);
            _flag.SetActive(true);
            
            var itemInSlot = _itemInSlot;   
            _itemInSlot = null;
            _towerItem = null;
            return itemInSlot;
        }
    }
}