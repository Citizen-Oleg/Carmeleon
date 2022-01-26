using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using EnemyComponent;
using EnemyComponent.Manager;
using Event;
using ScriptsLevels.Level;
using ScriptsMenu.Settings;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using Spawner;
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
        private SettingsGame _settingsGame;
        private EnemyManager _enemyManager;

        private void Awake()
        {
            _settingsGame = GameManager.SettingsGame;
            _enemyManager = LevelManager.EnemyManager;
            _healthBarPool = new MonoBehaviourPool<HealthBar>(_prefabHealthBar, _container, 10);

            _settingsGame.OnChangeHealthDisplay += DisplayHealthBar;
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyCreatedEvent>(OnEnemyCreated),
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroy)
            };
        }
        
        private void DisplayHealthBar(bool hasHealthDisplay)
        {
            if (hasHealthDisplay)
            {
                foreach (var enemy in _enemyManager.Enemies)
                {
                    CreateHealthBar(enemy);
                }
            }
            else
            {
                foreach (var enemy in _enemyManager.Enemies)
                {
                    DestroyHealthBar(enemy);
                }
            }
        }
        
        private void OnEnemyCreated(EnemyCreatedEvent enemyCreatedEvent)
        {
            if (_settingsGame.HasHealthDisplay)
            {
                CreateHealthBar(enemyCreatedEvent.Enemy);
            }
        }

        private void CreateHealthBar(Enemy enemy)
        {
            var enemyHealthBar = _healthBarPool.Take();
            enemyHealthBar.Initialize(enemy);
            _enemyHealthBars[enemy] = enemyHealthBar;
        }

        private void OnEnemyDestroy(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            if (_settingsGame.HasHealthDisplay)
            {
                DestroyHealthBar(enemyDestroyedEvent.Enemy);
            }
        }

        private void DestroyHealthBar(Enemy enemy)
        {
            if (_enemyHealthBars.ContainsKey(enemy))
            {
                _healthBarPool.Release(_enemyHealthBars[enemy]);
            }
        }
        
        private void OnDestroy()
        {
            _settingsGame.OnChangeHealthDisplay -= DisplayHealthBar;
            _subscriptions?.Dispose();
        }
    }
}
