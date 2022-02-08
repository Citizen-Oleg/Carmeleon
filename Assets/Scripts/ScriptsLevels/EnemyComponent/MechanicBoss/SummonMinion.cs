using System;
using System.Collections.Generic;
using EnemyComponent;
using Event;
using Factory;
using JetBrains.Annotations;
using ScriptsLevels.Event;
using ScriptsLevels.Level;
using SimpleEventBus;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptsLevels.EnemyComponent.MechanicBoss
{
    [RequireComponent(typeof(Enemy))]
    public class SummonMinion : MonoBehaviour
    {
        [SerializeField]
        private float _summonCooldown;
        [SerializeField]
        private List<Enemy> _servantsPrefab = new List<Enemy>();
        
        private bool IsCooldown => _startTime + _summonCooldown > Time.time;
        private float _startTime;

        private EnemyFactory _enemyFactory;
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _enemyFactory = LevelManager.EnemyFactory;
        }

        private void Update()
        {
            if (!IsCooldown && _enemy.CharacteristicsEnemy.IsMoving)
            {
                _enemy.CharacteristicsEnemy.IsCast = true;
                _enemy.EnemyAnimationController.Cast();
            }
        }

        [UsedImplicitly]
        private void EventSpawn()
        {
            var product = _enemyFactory.GetProduct(GetRandomEnemy());

            if (product is Enemy enemy)
            {
                enemy.transform.position = gameObject.transform.position;
                enemy.MovementEnemyController.Initialize(enemy, _enemy.MovementEnemyController.CurrentNode);
                
                EventStreams.UserInterface.Publish(new EnemySummon());
            }

            _enemy.EnemyAnimationController.ResetCast();
            _enemy.CharacteristicsEnemy.IsCast = false;
            _startTime = Time.time;
        }

        private Enemy GetRandomEnemy()
        {
            var index = Random.Range(0, _servantsPrefab.Count);
            return _servantsPrefab[index];
        }
    }
}
