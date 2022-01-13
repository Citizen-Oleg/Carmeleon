using System.Collections.Generic;
using EnemyComponent;
using Level.ScriptsMenu.Interface;
using Spawner;

namespace ScriptsMenu.Modifiers.LevelsModifier.Modifiers
{
    public class AdditionalBossModifier : IModifier
    {
        private readonly SpawnerEnemy _spawnerEnemy;
        private readonly Enemy _enemyPrefab;
        private readonly int _count;
        
        public AdditionalBossModifier(SpawnerEnemy spawnerEnemy, Enemy enemyPrefab, int count)
        {
            _spawnerEnemy = spawnerEnemy;
            _enemyPrefab = enemyPrefab;
            _count = count;
        }
        
        public void Activate()
        {
            var enemyData = new EnemySpawnData
            {
                Count = _count,
                Enemy = _enemyPrefab,
                StartNode = _spawnerEnemy.DefaultStartNode
            };

            var enemySpawnData = new List<EnemySpawnData> { enemyData };
            var wave = new WaveSpawn
            {
                EnemySpawnData = enemySpawnData
            };
            _spawnerEnemy.AddWave(wave);
        }
    }
}