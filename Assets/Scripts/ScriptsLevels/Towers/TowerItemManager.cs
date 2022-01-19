using System.Collections.Generic;
using Inventory;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace Towers
{
    public class TowerItemManager : MonoBehaviour
    {
        [SerializeField]
        private List<TowerItem> _towerItems = new List<TowerItem>();

        private readonly Dictionary<int, Tools.ObjectPool<Tower>> _towersPool = new Dictionary<int, Tools.ObjectPool<Tower>>();
        private readonly Dictionary<int, Tools.ObjectPool<GhostTower>> _ghostTowersPool = new Dictionary<int, Tools.ObjectPool<GhostTower>>();
        private TowerItem _towerItem;

        private void Awake()
        {
            foreach (var towersItem in _towerItems)
            {
                _towersPool.Add(towersItem.ID, new Tools.ObjectPool<Tower>(towersItem.Tower, 2));
                _ghostTowersPool.Add(towersItem.ID, new Tools.ObjectPool<GhostTower>(towersItem.GhostTower, 2));
            }
        }

        public TowerItem GetInitializedTowerItem(TowerItem towerItem)
        {
            var itemTower = Instantiate(towerItem);
            itemTower.Tower = GetTower(towerItem);
            itemTower.GhostTower = GetGhostTower(towerItem);
            return itemTower;
        }
        
        private GhostTower GetGhostTower(TowerItem towerItem)
        {
            if (!_ghostTowersPool.TryGetValue(towerItem.ID, out var pool))
            {
                pool = new Tools.ObjectPool<GhostTower>(towerItem.GhostTower, 2);
                _ghostTowersPool.Add(towerItem.ID, pool);
            }

            return pool.GetInactiveObject();
        }

        private Tower GetTower(TowerItem towerItem)
        {
            if (!_towersPool.TryGetValue(towerItem.ID, out var pool))
            {
                pool = new Tools.ObjectPool<Tower>(towerItem.Tower, 2);
                _towersPool.Add(towerItem.ID, pool);
            }

            return pool.GetInactiveObject();
        }
    }
}