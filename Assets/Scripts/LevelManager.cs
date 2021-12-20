using EnemyComponent;
using EnemyComponent.Manager;
using Factory;
using Inventory;
using Spawner;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static SpawnerEnemy SpawnerEnemy => instance._spawnerEnemy;
    public static EnemyManager EnemyManager => instance._enemyManager;
    public static ProjectileFactory ProjectileFactory => instance._projectileFactory;
    public static InventoryScreen InventoryScreen => instance._inventoryScreen;

    [SerializeField]
    private InventoryScreen _inventoryScreen;
    [SerializeField]
    private ProjectileFactory _projectileFactory;
    [SerializeField]
    private SpawnerEnemy _spawnerEnemy;
    [SerializeField]
    private EnemyManager _enemyManager;
}