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
        private readonly float _delayedSpawnEnemies;
        
        public AdditionalBossModifier(SpawnerEnemy spawnerEnemy, Enemy enemyPrefab, int count, float delayedSpawnEnemies)
        {
            _spawnerEnemy = spawnerEnemy;
            _enemyPrefab = enemyPrefab;
            _count = count;
            _delayedSpawnEnemies = delayedSpawnEnemies;
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

            var exitSpawnDate = new List<ExitSpawnData>
            {
                new ExitSpawnData
                {
                    DelayedSpawnEnemies = _delayedSpawnEnemies,
                    EnemySpawnData = enemySpawnData  
                }
            };
                
                
            var wave = new WaveSpawn
            {
                ExitSpawnData = exitSpawnDate
            };
            _spawnerEnemy.AddWave(wave);
        }
    }
}