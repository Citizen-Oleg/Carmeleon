using Inventory;

namespace Interface
{
    public interface IBehaviorPlaceInstallation
    {
        bool HasBlock { get; }
        bool HasBusy(TowerItem towerItem);

        void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem);
        ItemInSlot DestroyTower();
    }
}