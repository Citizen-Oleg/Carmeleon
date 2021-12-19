using EnemyComponent;
using EnemyComponent.Manager;
using Factory;
using Spawner;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static SpawnerEnemy SpawnerEnemy => instance._spawnerEnemy;
    public static EnemyManager EnemyManager => instance._enemyManager;
    public static ProjectileFactory ProjectileFactory => instance._projectileFactory;

    [SerializeField]
    private ProjectileFactory _projectileFactory;
    [SerializeField]
    private SpawnerEnemy _spawnerEnemy;
    [SerializeField]
    private EnemyManager _enemyManager;
}