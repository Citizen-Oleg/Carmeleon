using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using SimpleEventBus;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс отвечает за спавн врагов на карте
    /// </summary>
    public class SpawnerEnemy : MonoBehaviour
    {
        [SerializeField]
        private float _delayedSpawnEnemies;
        [SerializeField]
        private List<WaveSpawn> _waveSpawns = new List<WaveSpawn>();
        
        private int _waveNumber;
        private IDisposable _subscription;

        private void Awake()
        {
            _subscription = EventStreams.UserInterface.Subscribe<EventWaveSweep>(StartWave);
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }
        
        private void StartWave(EventWaveSweep eventWaveSweep)
        {
            if (_waveNumber > _waveSpawns.Count)
            {
               //TODO: Эвент на открытие окна победы
            }
            else
            {
                StartCoroutine(Spawn()); 
            }
        }
        
        private IEnumerator Spawn()
        {
            var wave = _waveSpawns[_waveNumber++];

            foreach (var enemyData in wave.EnemySpawnData)
            {
                for (var i = 0; i < enemyData.Count; i++)
                {
                    var enemy = Instantiate(enemyData.Enemy, enemyData.StartNode.transform.position, Quaternion.identity);
                    enemy.MovementEnemyController.Initialize(enemyData.StartNode);

                    yield return new WaitForSeconds(_delayedSpawnEnemies);
                }
            }
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}
