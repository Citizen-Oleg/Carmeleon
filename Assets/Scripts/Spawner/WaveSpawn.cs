using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс для создания волн
    /// </summary>
    [Serializable]
    public class WaveSpawn
    {
        public List<EnemySpawnData> EnemySpawnData => _enemySpawnData;

        [SerializeField]
        private List<EnemySpawnData> _enemySpawnData = new List<EnemySpawnData>();
    }
}