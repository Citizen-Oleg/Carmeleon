using Inventory;
using UnityEngine;

namespace DragController
{
    [RequireComponent(typeof(Collider2D))]
    public class PlaceInstallationTower : MonoBehaviour
    {
        public bool HasBusy => _itemInSlot != null && _towerItem != null;

        [SerializeField]
        private Transform _installationPosition;
        [SerializeField]
        private GameObject _flag;
        
        private ItemInSlot _itemInSlot;
        private TowerItem _towerItem;
        
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
            var itemInSlot = _itemInSlot;
            
            _towerItem.Tower.gameObject.SetActive(false);
            _itemInSlot = null;
            _towerItem = null;
            
            _flag.SetActive(true);
            return itemInSlot;
        }
    }
}