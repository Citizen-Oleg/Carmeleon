using System.Collections;
using System.Collections.Generic;
using Inventory;
using JetBrains.Annotations;
using Towers;
using UnityEngine;

public class TestTower : MonoBehaviour
{
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private TowerItem _towerItem;

    [UsedImplicitly]
    public void Click()
    {
        var towerItem = Instantiate(_towerItem);
        var tower = Instantiate(towerItem.Tower);
        tower.gameObject.SetActive(false);
        var ghostTower = Instantiate(towerItem.GhostTower);
        ghostTower.gameObject.SetActive(false);
        towerItem.Tower = tower;
        towerItem.GhostTower = ghostTower;
        var itemInSlot = new ItemInSlot(towerItem);
        _inventoryManager.AddItemToSlot(itemInSlot);
    }
}
