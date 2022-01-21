using Inventory;
using ScriptsLevels.Inventory;

namespace Interface
{
    public interface IBehaviorPlaceInstallation
    {
        bool HasBlock { get; }
        bool HasBusy(TowerItem towerItem);
        float BlockDuration { get; }

        void InstallTower(ItemInSlot itemInSlot, TowerItem towerItem);
        ItemInSlot DestroyTower();
    }
}