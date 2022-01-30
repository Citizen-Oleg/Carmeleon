using System;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(IBuffBehaviour<Enemy>))]
    [RequireComponent(typeof(Collider2D))]
    public class PassiveRadiusBuffEnemy : MonoBehaviour
    {
        private IBuffBehaviour<Enemy> _buffBehaviour;

        private void Awake()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Enemy>>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                _buffBehaviour.BuffTarget(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                _buffBehaviour.StopBuffTarget(enemy);
            }
        }
    }
}