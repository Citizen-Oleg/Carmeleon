using System;
using System.Linq;
using EnemyComponent.Manager;
using Event;
using Level;
using ScriptsLevels.Level;
using SimpleEventBus;
using TMPro;
using UnityEngine;

namespace View
{
    public class EnemiesLevelView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _currentNumberEnemies;
        [SerializeField]
        private TextMeshProUGUI _maxNumberEnemies;

        private int _currentDeaths;
        private EnemyManager _enemyManager;
        private IDisposable _subscription;
        
        private void Start()
        {
            _subscription = EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(RefreshUI);

            var waves = LevelManager.SpawnerEnemy.WaveSpawns;
            var amountEnemiesLevel = waves.SelectMany(waveSpawn => waveSpawn.EnemySpawnData).Sum(spawnData => spawnData.Count);
            _maxNumberEnemies.text = amountEnemiesLevel.ToString();
            _currentNumberEnemies.text = "0";
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }

        private void RefreshUI(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            _currentDeaths++;
            _currentNumberEnemies.text = _currentDeaths.ToString();
        }
    }
}