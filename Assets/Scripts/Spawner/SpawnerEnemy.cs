using System;
using System.Collections;
using System.Collections.Generic;
using EnemyComponent;
using Event;
using Factory;
using SimpleEventBus;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс отвечает за спавн врагов на карте
    /// </summary>
    [RequireComponent(typeof(IFactory<TypeEnemy>))]
    public class SpawnerEnemy : MonoBehaviour
    {
        public bool HasSpawning => _hasSpawning;

        [SerializeField]
        private float _delayedSpawnEnemies;
        [SerializeField]
        private List<WaveSpawn> _waveSpawns = new List<WaveSpawn>();
        
        private int _waveNumber;
        private IDisposable _subscription;
        private IFactory<TypeEnemy> _enemyFactory;
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
        
        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
        
        private void StartWave(EventWaveSweep eventWaveSweep)
        {
            if (_waveNumber >= _waveSpawns.Count)
            {
                Debug.Log("Окно победы");
               //TODO: Эвент на открытие окна победы
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

            foreach (var enemyData in wave.EnemySpawnData)
            {
                for (var i = 0; i < enemyData.Count; i++)
                {
                    yield return new WaitForSeconds(_delayedSpawnEnemies);
                    
                    var enemy = _enemyFactory.GetProduct<Enemy>(enemyData.TypeEnemy);
                    enemy.transform.position = enemyData.StartNode.transform.position;
                    enemy.MovementEnemyController.Initialize(enemy, enemyData.StartNode);
                    
                    EventStreams.UserInterface.Publish(new EnemyCreatedEvent(enemy));
                }
            }

            _hasSpawning = false;
        }
    }
}
