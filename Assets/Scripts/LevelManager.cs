﻿using EnemyComponent;
using EnemyComponent.Manager;
using Factory;
using Inventory;
using ResourceManager;
using Spawner;
using Towers;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static SpawnerEnemy SpawnerEnemy => instance._spawnerEnemy;
    public static EnemyManager EnemyManager => instance._enemyManager;
    public static ProjectileFactory ProjectileFactory => instance._projectileFactory;
    public static InventoryScreen InventoryScreen => instance._inventoryScreen;
    public static TowerItemManager TowerItemManager => instance._towerItemManager;
    public static InventoryManager InventoryManager => instance._inventoryManager;
    public static ResourceManagerLevel ResourceManagerLevel => instance._resourceManagerLevel;

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
}