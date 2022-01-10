using System.Collections.Generic;
using Event;
using Level;
using ScriptsLevels.Level;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using Spawner;
using UnityEngine;

namespace EnemyComponent.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        public List<Enemy> Enemies => _enemies;

        private List<Enemy> _enemies = new List<Enemy>();
        private CompositeDisposable _subscriptions;
        private SpawnerEnemy _spawnerEnemy;
        
        private void Awake()
        {
            _spawnerEnemy = LevelManager.SpawnerEnemy;
            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyCreatedEvent>(AddEnemy),
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroy)
            };
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }

        private void AddEnemy(EnemyCreatedEvent enemyCreatedEvent)
        {
            _enemies.Add(enemyCreatedEvent.Enemy);
        }

        private void OnEnemyDestroy(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            _enemies.Remove(enemyDestroyedEvent.Enemy);

            if (_enemies.Count == 0 && !_spawnerEnemy.HasSpawning)
            {
                Debug.Log("Все враги убиты");
                EventStreams.UserInterface.Publish(new EventWaveSweep());
            }
        }
    }
}
