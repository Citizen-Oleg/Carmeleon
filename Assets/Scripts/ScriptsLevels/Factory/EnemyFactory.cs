using System.Collections.Generic;
using EnemyComponent;
using Event;
using Interface;
using ScriptsLevels.Level;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Factory
{
    /// <summary>
    /// Класс предназначен для выдачи врага
    /// </summary>
    public class EnemyFactory : MonoBehaviour, IFactory
    {
        [SerializeField]
        private Transform _containerEnemy;
        [SerializeField]
        private List<Enemy> _enemies = new List<Enemy>();

        private readonly Dictionary<int, MonoBehaviourPool<Enemy>> _enemyPool =
            new Dictionary<int, MonoBehaviourPool<Enemy>>();
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
            foreach (var enemy in _enemies)
            {
                var pool = new MonoBehaviourPool<Enemy>(enemy, _containerEnemy, 10);
                _enemyPool.Add(enemy.ID, pool);
            }

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroyed)
            };
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
        
        public IProduct GetProduct(IProduct product)
        {
            var enemy = _enemyPool[product.ID].Take();
            enemy.EnemyBuffController.ResetBuff();
            ResetCharacteristics(enemy);
            return enemy;
        }

        private void ResetCharacteristics(Enemy enemy)
        {
            var characteristics = enemy.CharacteristicsEnemy;

            var levelSettings = LevelManager.LevelSettings;

            characteristics.PercentageIncreaseSpeed = levelSettings.EnemySpeedIncreasePercentage;
            characteristics.PercentageIncreaseMaxHp = levelSettings.PercentageIncreaseHealth;
            
            characteristics.CurrentHp = characteristics.MaxHp;

            enemy.EnemyAnimationController.DefaultState();
            
            characteristics.IsDeath = false;
            characteristics.IsMoving = true;
        }
        
        public void ReleaseProduct(IProduct product)
        {
            var enemy = (Enemy) product;
            _enemyPool[product.ID].Release(enemy);
        }

        private void OnEnemyDestroyed(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            ReleaseProduct(enemyDestroyedEvent.Enemy);
        }
    }
} 