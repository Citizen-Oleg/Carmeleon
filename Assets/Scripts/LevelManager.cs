using EnemyComponent;
using EnemyComponent.Manager;
using Spawner;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public static SpawnerEnemy SpawnerEnemy => instance._spawnerEnemy;
    public static EnemyManager EnemyManager => instance._enemyManager;

    [SerializeField]
    private SpawnerEnemy _spawnerEnemy;
    [SerializeField]
    private EnemyManager _enemyManager;
}