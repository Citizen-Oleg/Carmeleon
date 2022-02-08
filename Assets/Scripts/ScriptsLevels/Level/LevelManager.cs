using System;
using EnemyComponent.Manager;
using Factory;
using Inventory;
using Inventory.Craft;
using Loot;
using ResourceManager;
using ScreenManager;
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
        public static ManagerTower ManagerTower => instance._managerTower;
        public static EnemyFactory EnemyFactory => instance._enemyFactory;

        public StateLevel StateLevel => _stateLevel;

        [SerializeField]
        private ManagerTower _managerTower;
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
        private EnemyFactory _enemyFactory;
        [SerializeField]
        private SpawnerEnemy _spawnerEnemy;
        [SerializeField]
        private EnemyManager _enemyManager;
        [SerializeField]
        private LevelSettings _levelSettings;

        private StateLevel _stateLevel;

        private void Start()
        {
            SetState(StateLevel.Normal);
        }

        public void SetState(StateLevel newState, float speed = 1f)
        {
            _stateLevel = newState;

            switch (newState)
            {
                case StateLevel.Normal:
                    Time.timeScale = speed;
                    break;
                case StateLevel.Pause:
                    Time.timeScale = 0;
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.ScreenManager.OpenScreen(ScreenType.ExitView);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            SetState(StateLevel.Normal);
        }
    }
}