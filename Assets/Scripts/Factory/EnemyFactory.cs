using System.Collections.Generic;
using Enemy;
using Event;
using SimpleEventBus;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace Factory
{
    /// <summary>
    /// Класс предназначен для выдачи врага
    /// </summary>
    public class EnemyFactory : MonoBehaviour, IFactory<TypeEnemy>
    {
        [SerializeField]
        private Transform _containerEnemy;
        [SerializeField]
        private Enemy.Enemy _prefabEnemy;
        [SerializeField]
        private List<Enemy.Enemy> _enemies = new List<Enemy.Enemy>();

        private MonoBehaviourPool<Enemy.Enemy> _enemyPool;
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
            _enemyPool = new MonoBehaviourPool<Enemy.Enemy>(_prefabEnemy, _containerEnemy, 10);

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroyed)
            };
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
        
        public TProduct GetProduct<TProduct>(TypeEnemy typeProduct) where TProduct : Product
        {
            var enemy = _enemyPool.Take();

            SetSpriteByTypeEnemy(typeProduct, ref enemy);
            SetCharacteristicsEnemyByType(typeProduct, ref enemy);
            enemy.Reboot();
            
            return (TProduct) (Product) enemy;
        }
        
        private void OnEnemyDestroyed(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            _enemyPool.Release(enemyDestroyedEvent.Enemy);
        }

        private void SetCharacteristicsEnemyByType(TypeEnemy typeEnemy, ref Enemy.Enemy productEnemy)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.TypeEnemy == typeEnemy)
                {
                    var characteristicsEnemy = enemy.CharacteristicsEnemy;
                    var productCharacteristics = productEnemy.CharacteristicsEnemy;

                    productCharacteristics.Armor = characteristicsEnemy.Armor;
                    productCharacteristics.Speed = characteristicsEnemy.Speed;
                    productCharacteristics.AirResistance = characteristicsEnemy.AirResistance;
                    productCharacteristics.CurrentHp = characteristicsEnemy.CurrentHp;
                    productCharacteristics.EarthResistance = characteristicsEnemy.EarthResistance;
                    productCharacteristics.FireResistance = characteristicsEnemy.FireResistance;
                    productCharacteristics.MaxHp = characteristicsEnemy.MaxHp;
                    productCharacteristics.WaterResistance = characteristicsEnemy.WaterResistance;
                    productCharacteristics.DamageToBase = characteristicsEnemy.DamageToBase;
                }
            }
        }
        
        private void SetSpriteByTypeEnemy(TypeEnemy typeEnemy, ref Enemy.Enemy productEnemy)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.TypeEnemy == typeEnemy)
                {
                    var characteristicsEnemy = enemy.SpriteRenderer;
                    var productCharacteristics = productEnemy.SpriteRenderer;

                    productCharacteristics.color = characteristicsEnemy.color;
                    productCharacteristics.sprite = characteristicsEnemy.sprite;
                }
            }
        }
    }
} 