using System;
using System.Linq;
using EnemyComponent.Manager;
using Event;
using Level;
using ScriptsLevels.Event;
using ScriptsLevels.Level;
using SimpleEventBus;
using SimpleEventBus.Disposables;
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
        private int _totalEnemies;
        
        private EnemyManager _enemyManager;
        private CompositeDisposable _subscriptions;
        
        private void Start()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(RefreshUI),
                EventStreams.UserInterface.Subscribe<EnemySummon>(RefreshUI)
            };
            
            var waves = LevelManager.SpawnerEnemy.WaveSpawns;
            _totalEnemies = waves.Sum(waveSpawn => waveSpawn.ExitSpawnData.Sum(exitSpawnData => exitSpawnData.EnemySpawnData.Sum(spawnData => spawnData.Count)));

            _maxNumberEnemies.text = _totalEnemies.ToString();
            _currentNumberEnemies.text = "0";
        }

        private void RefreshUI(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            _currentDeaths++;
            _currentNumberEnemies.text = _currentDeaths.ToString();
        }

        private void RefreshUI(EnemySummon enemySummon)
        { 
            _totalEnemies++;
            _maxNumberEnemies.text = _totalEnemies.ToString();
        }
        
        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
    }
}