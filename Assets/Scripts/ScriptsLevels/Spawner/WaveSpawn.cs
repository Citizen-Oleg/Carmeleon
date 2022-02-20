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
        public List<ExitSpawnData> ExitSpawnData
        {
            get => _exitSpawnData;
            set => _exitSpawnData = value;
        }

        [SerializeField]
        private List<ExitSpawnData> _exitSpawnData = new List<ExitSpawnData>();
    }
}