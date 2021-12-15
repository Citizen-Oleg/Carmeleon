using System;
using System.Collections.Generic;
using EnemyComponent;
using Event;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace ManagerHB
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField]
        private HealthBar _prefabHealthBar;
        [SerializeField]
        private RectTransform _container;

        private readonly Dictionary<Enemy, HealthBar> _enemyHealthBars = new Dictionary<Enemy, HealthBar>();
        private MonoBehaviourPool<HealthBar> _healthBarPool;
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _healthBarPool = new MonoBehaviourPool<HealthBar>(_prefabHealthBar, _container, 10);

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyCreatedEvent>(OnEnemyCreated),
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroy)
            };
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }

        private void OnEnemyCreated(EnemyCreatedEvent enemyCreatedEvent)
        {
            CreateHealthBar(enemyCreatedEvent.Enemy);
        }

        private void CreateHealthBar(Enemy enemy)
        {
            var enemyHealthBar = _healthBarPool.Take();
            enemyHealthBar.Initialize(enemy);
            _enemyHealthBars[enemy] = enemyHealthBar;
        }

        private void OnEnemyDestroy(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            var enemy = enemyDestroyedEvent.Enemy;

            if (_enemyHealthBars.ContainsKey(enemy))
            {
                _healthBarPool.Release(_enemyHealthBars[enemy]);
            }
        }
    }
}
