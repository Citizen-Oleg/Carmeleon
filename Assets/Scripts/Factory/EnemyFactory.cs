using System.Collections.Generic;
using Enemy;
using Event;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform _containerEnemy;
        [SerializeField]
        private List<Enemy.Enemy> _enemies = new List<Enemy.Enemy>();

        private Dictionary<TypeEnemy, MonoBehaviourPool<Enemy.Enemy>> _enemyPool = new Dictionary<TypeEnemy, MonoBehaviourPool<Enemy.Enemy>>();
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
            foreach (var enemy in _enemies)
            {
                _enemyPool.Add(enemy.TypeEnemy, new MonoBehaviourPool<Enemy.Enemy>(enemy, _containerEnemy));
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

        public Enemy.Enemy GetEnemy(TypeEnemy typeEnemy)
        {
            return _enemyPool.ContainsKey(typeEnemy) ? _enemyPool[typeEnemy].Take() : null;
        }

        private void OnEnemyDestroyed(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            if (_enemyPool.ContainsKey(enemyDestroyedEvent.TypeEnemy))
            {
                _enemyPool[enemyDestroyedEvent.TypeEnemy].Release(enemyDestroyedEvent.Enemy);
            }
        }
    }
}