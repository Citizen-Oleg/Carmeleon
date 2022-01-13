using System;
using EnemyComponent.Manager;
using Factory;
using Inventory;
using Inventory.Craft;
using Loot;
using ResourceManager;
using Spawner;
using Tools;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Level
{
    public class LevelManager : Singleton<LevelManager>
    {
        public static SpawnerEnemy SpawnerEnemy => instance._spawnerEnemy;
        public static EnemyManager EnemyManager => instance._enemyManager;
        public static ProjectileFactory ProjectileFactory => instance._projectileFactory;
        public static InventoryScreen InventoryScreen => instance._inventoryScreen;
        public static TowerItemManager TowerItemManager => instance._towerItemManager;
        public static InventoryManager InventoryManager => instance._inventoryManager;
        public static ResourceManagerLevel ResourceManagerLevel => instance._resourceManagerLevel;
        public static CraftController CraftController => instance._craftController;
        public static ReagentPool ReagentPool => instance._reagentPool;
        public static LevelSettings LevelSettings => instance._levelSettings;

        [SerializeField]
        private ReagentPool _reagentPool;
        [SerializeField]
        private CraftController _craftController;
        [SerializeField]
        private ResourceManagerLevel _resourceManagerLevel;
        [SerializeField]
        private InventoryManager _inventoryManager;
        [SerializeField]
        private TowerItemManager _towerItemManager;
        [SerializeField]
        private InventoryScreen _inventoryScreen;
        [SerializeField]
        private ProjectileFactory _projectileFactory;
        [SerializeField]
        private SpawnerEnemy _spawnerEnemy;
        [SerializeField]
        private EnemyManager _enemyManager;
        [SerializeField]
        private LevelSettings _levelSettings;

        private void Start()
        {
            Time.timeScale = 1;
        }
    }
}