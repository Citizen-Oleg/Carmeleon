using System;
using EnemyComponent;
using Event;
using SimpleEventBus;
using UnityEngine;

namespace ManagerHB
{
    [RequireComponent(typeof(CharacteristicsEnemy))]
    public class HealthBehavior : MonoBehaviour
    {
        private Enemy _enemy;
        
        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }
        
        public void TakeDamage(int damage)
        {
            _enemy.CharacteristicsEnemy.CurrentHp -= damage;

            if (_enemy.CharacteristicsEnemy.CurrentHp <= 0)
            {
                EventStreams.UserInterface.Publish(new EnemyDestroyedEvent(_enemy));
            }
        }

        public void RestoreHealth(int recovery)
        {
            _enemy.CharacteristicsEnemy.CurrentHp += recovery;
        }
    }
}
