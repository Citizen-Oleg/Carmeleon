using System;
using System.Collections;
using System.Collections.Generic;
using EnemyComponent;
using Event;
using Factory;
using Interface;
using NodeMovement;
using ScriptsLevels.Event;
using SimpleEventBus;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс отвечает за спавн врагов на карте
    /// </summary>
    [RequireComponent(typeof(IFactory))]
    public class SpawnerEnemy : MonoBehaviour
    {
        public bool HasSpawning => _hasSpawning;
        public List<WaveSpawn> WaveSpawns => _waveSpawns;
        public Node DefaultStartNode => _defaultStartNode;

        [SerializeField]
        private float _startDelay;
        [SerializeField]
        private float _delayedSpawnEnemies;
        [SerializeField]
        private Node _defaultStartNode;
        [SerializeField]
        private List<WaveSpawn> _waveSpawns = new List<WaveSpawn>();
        
        private int _waveNumber;
        private IDisposable _subscription;
        private IFactory _enemyFactory;
        private bool _hasSpawning;

        private void Awake()
        {
            _enemyFactory = GetComponent<EnemyFactory>();
            _subscription = EventStreams.UserInterface.Subscribe<EventWaveSweep>(StartWave);
        }

        private void Start()
        {
            StartWave(new EventWaveSweep());
        }

        public void AddWave(WaveSpawn waveSpawn)
        {
            _waveSpawns.Add(waveSpawn);
        }
        
        private void StartWave(EventWaveSweep eventWaveSweep)
        {
            if (_waveNumber >= _waveSpawns.Count)
            {
                EventStreams.UserInterface.Publish(new EventCompletingLevel());
            }
            else
            {
                StartCoroutine(Spawn()); 
            }
        }
        
        private IEnumerator Spawn()
        {
            _hasSpawning = true;
            var wave = _waveSpawns[_waveNumber++];

            yield return new WaitForSeconds(_startDelay);
            
            foreach (var enemyData in wave.EnemySpawnData)
            {
                for (var i = 0; i < enemyData.Count; i++)
                {
                    var product = _enemyFactory.GetProduct(enemyData.Enemy);
                    
                    if (product is Enemy enemy)
                    {
                        var node = enemyData.StartNode == null ? _defaultStartNode : enemyData.StartNode;
                        enemy.transform.position = node.transform.position;
                        enemy.MovementEnemyController.Initialize(enemy, node);
                    
                        EventStreams.UserInterface.Publish(new EnemyCreatedEvent(enemy));
                    }
                    
                    yield return new WaitForSeconds(_delayedSpawnEnemies);
                }
            }

            _hasSpawning = false;
        }
        
        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}
