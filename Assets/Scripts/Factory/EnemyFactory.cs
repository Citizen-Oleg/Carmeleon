using System;
using System.Collections.Generic;
using EnemyComponent;
using Event;
using Interface;
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
        private Enemy _prefabEnemy;
        [SerializeField]
        private List<Enemy> _enemies = new List<Enemy>();

        private MonoBehaviourPool<Enemy> _enemyPool;
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
            _enemyPool = new MonoBehaviourPool<Enemy>(_prefabEnemy, _containerEnemy, 30);

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroyed)
            };

            _enemies = BubbleSortProduct.GetSortList(_enemies);
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
        
        public IProduct GetProduct(IProduct product)
        {
            var enemy = _enemyPool.Take();
            var enemyBlueprint = GetEnemyById(product.ID);
       
            SetSpriteEnemy(enemyBlueprint, ref enemy);
            SetCharacteristicsEnemy(enemyBlueprint, ref enemy);
            SetLootEnemy(enemyBlueprint, ref enemy);

            return enemy;
        }

        public void ReleaseProduct(IProduct product)
        {
            _enemyPool.Release((Enemy)product);   
        }

        private void OnEnemyDestroyed(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            ReleaseProduct(enemyDestroyedEvent.Enemy);
        }

        /// <summary>
        /// Для корректной работы нужно добавить всех врагов в массив _enemies.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Enemy GetEnemyById(int id)
        {
            return _enemies[id];
        }

        private void SetLootEnemy(Enemy enemyBlueprint, ref Enemy productEnemy)
        {
            var lootEnemy = enemyBlueprint.LootController;
            var productLootEnemy = productEnemy.LootController;

            productLootEnemy.Resource = lootEnemy.Resource;
        }

        private void SetCharacteristicsEnemy(Enemy enemyBlueprint, ref Enemy productEnemy)
        {
            var characteristicsEnemy = enemyBlueprint.CharacteristicsEnemy;
            var productCharacteristics = productEnemy.CharacteristicsEnemy;
            
            productCharacteristics.Armor = characteristicsEnemy.Armor;
            productCharacteristics.Speed = characteristicsEnemy.Speed;
            productCharacteristics.AirResistance = characteristicsEnemy.AirResistance;
            productCharacteristics.EarthResistance = characteristicsEnemy.EarthResistance;
            productCharacteristics.FireResistance = characteristicsEnemy.FireResistance;
            productCharacteristics.MaxHp = characteristicsEnemy.MaxHp;
            productCharacteristics.CurrentHp = characteristicsEnemy.MaxHp;
            productCharacteristics.WaterResistance = characteristicsEnemy.WaterResistance;
            productCharacteristics.DamageToBase = characteristicsEnemy.DamageToBase;
            productCharacteristics.IsDeath = false;
            productEnemy.OffSetPositionHealthBar = enemyBlueprint.OffSetPositionHealthBar;
        }
        
        private void SetSpriteEnemy(Enemy enemyBlueprint, ref Enemy productEnemy)
        {
            var spriteRendererEnemy = enemyBlueprint.SpriteRenderer;
            var spriteRendererProduct = productEnemy.SpriteRenderer;

            spriteRendererProduct.color = spriteRendererEnemy.color;
            spriteRendererProduct.sprite = spriteRendererEnemy.sprite;
        }
    }
} 