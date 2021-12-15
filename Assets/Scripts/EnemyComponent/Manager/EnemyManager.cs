using System.Collections.Generic;
using DefaultNamespace;
using Event;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace EnemyComponent.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private LevelController _levelController;
        
        private List<Enemy> _enemies = new List<Enemy>();
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
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

            if (_enemies.Count == 0 && !_levelController.SpawnerEnemy.HasSpawning)
            {
                Debug.Log("Все враги убиты");
                EventStreams.UserInterface.Publish(new EventWaveSweep());
            }
        }
    }
}
