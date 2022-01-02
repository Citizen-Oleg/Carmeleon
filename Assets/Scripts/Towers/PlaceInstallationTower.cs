using Inventory;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Collider2D))]
    public class PlaceInstallationTower : MonoBehaviour
    {
        public bool HasBusy => _itemInSlot != null && _towerItem != null;
        public bool HasBlock => _blockTime > Time.time;
        
        [SerializeField]
        private Transform _installationPosition;
        [SerializeField]
        private GameObject _flag;
        [SerializeField]
        private float _blockDuration;
        
        private ItemInSlot _itemInSlot;
        private TowerItem _towerItem;

        private float _blockTime;
        
        public void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem)
        {
            _itemInSlot = itemInSlot;
            _towerItem = towerItem;
            
            _flag.SetActive(false);
            _towerItem.Tower.transform.position = _installationPosition.position;
            _towerItem.Tower.gameObject.SetActive(true);
        }

        public ItemInSlot DestroyTower()
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