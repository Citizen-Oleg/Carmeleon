using System;
using System.Linq;
using EnemyComponent.Manager;
using Event;
using Level;
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
        
        private void Awake()
        {
            _subscription = EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(RefreshUI);

            var waves = LevelManager.SpawnerEnemy.WaveSpawns;
            var amountEnemiesLevel = waves.SelectMany(WaveSpawn => WaveSpawn.EnemySpawnData).Sum(spawnData => spawnData.Count);
            _maxNumberEnemies.text = amountEnemiesLevel.ToString();
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