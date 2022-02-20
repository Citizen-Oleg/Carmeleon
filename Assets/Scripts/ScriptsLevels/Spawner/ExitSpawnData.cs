using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    [Serializable]
    public class ExitSpawnData
    {
        public float DelayedSpawnEnemies
        {
            get => _delayedSpawnEnemies;
            set => _delayedSpawnEnemies = value;
        }

        public List<EnemySpawnData> EnemySpawnData
        {
            get => _enemySpawnData;
            set => _enemySpawnData = value;
        }

        [SerializeField]
        private float _delayedSpawnEnemies;
        [SerializeField]
        private List<EnemySpawnData> _enemySpawnData = new List<EnemySpawnData>();
    }
}