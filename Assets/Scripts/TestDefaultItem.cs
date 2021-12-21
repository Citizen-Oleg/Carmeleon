using Inventory;
using JetBrains.Annotations;
using UnityEngine;

public class TestDefaultItem : MonoBehaviour
{
    [SerializeField]
    private InventoryManager _inventoryManager;
    [SerializeField]
    private Item _Item;

    [UsedImplicitly]
    public void Click()
    {
        _inventoryManager.AddItemToTwoSlot(new ItemInSlot(_Item));
    }
}
