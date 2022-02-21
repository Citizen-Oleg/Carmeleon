using System;
using Event;
using Player;
using ScriptsLevels.Event;
using SimpleEventBus;
using Towers;
using UnityEngine;

namespace EnemyComponent
{
    /// <summary>
    /// Класс отвечает за нанесение урона врагом.
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class AttackBehaviourEnemy : MonoBehaviour
    {
        public event Action OnAttackBase; 
        
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _enemy.MovementEnemyController.OnFinishPoint += Attack;
        }
        
        private void Attack()
        {
            EventStreams.UserInterface.Publish(new DamageBasePlayerEvent(_enemy.CharacteristicsEnemy.DamageToBase));
            OnAttackBase?.Invoke();
        }

        private void OnDestroy()
        {
            if (_enemy != null)
            {
                _enemy.MovementEnemyController.OnFinishPoint -= Attack;
            }
        }
    }
}