using System;
using System.Collections.Generic;
using EnemyComponent;
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
        private Enemy _prefabEnemy;
        [SerializeField]
        private List<Enemy> _enemies = new List<Enemy>();

        private MonoBehaviourPool<Enemy> _enemyPool;
        private CompositeDisposable _subscriptions;
        
        private void Awake()
        {
            _enemyPool = new MonoBehaviourPool<Enemy>(_prefabEnemy, _containerEnemy, 10);

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<EnemyDestroyedEvent>(OnEnemyDestroyed)
            };

            _enemies = new BubbleSort().GetSortList(_enemies);
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
        
        public TProduct GetProduct<TProduct>(TypeEnemy typeProduct) where TProduct : IProduct<TypeEnemy>
        {
            var enemy = _enemyPool.Take();
            var enemyBlueprint = GetEnemyByType(typeProduct);
       
            SetSpriteByTypeEnemy(enemyBlueprint, ref enemy);
            SetCharacteristicsEnemyByType(enemyBlueprint, ref enemy);

            return (TProduct) (IProduct<TypeEnemy>) enemy;
        }
        
        private void OnEnemyDestroyed(EnemyDestroyedEvent enemyDestroyedEvent)
        {
            _enemyPool.Release(enemyDestroyedEvent.Enemy);
        }

        /// <summary>
        /// Для корректной работы нужно добавить все типы врагов в массив _enemies.
        /// </summary>
        /// <param name="typeEnemy"></param>
        /// <returns></returns>
        private Enemy GetEnemyByType(TypeEnemy typeEnemy)
        {
            return _enemies[(int) typeEnemy];
        }

        private void SetCharacteristicsEnemyByType(Enemy enemyBlueprint, ref Enemy productEnemy)
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
        
        private void SetSpriteByTypeEnemy(Enemy enemyBlueprint, ref Enemy productEnemy)
        {
            var characteristicsEnemy = enemyBlueprint.SpriteRenderer;
            var productCharacteristics = productEnemy.SpriteRenderer;

            productCharacteristics.color = characteristicsEnemy.color;
            productCharacteristics.sprite = characteristicsEnemy.sprite;
        }
    }

    class BubbleSort
    {
        public List<T> GetSortList<T>(List<T> list) where T : IProduct<TypeEnemy>
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count ; j++)
                {
                    if ((int) list[i].TypeEnum > (int)list[j].TypeEnum)
                    {
                        (list[i], list[j]) = (list[j], list[i]);
                    }
                }
            }
            
            return list;
        }
    }
} 