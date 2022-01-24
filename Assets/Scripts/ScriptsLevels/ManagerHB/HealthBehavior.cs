using System;
using EnemyComponent;
using Event;
using SimpleEventBus;
using Towers;
using UnityEngine;

namespace ManagerHB
{
    [RequireComponent(typeof(CharacteristicsEnemy))]
    public class HealthBehavior : MonoBehaviour
    {
        public event Action<Enemy> OnDead;
        public event Action OnReceivedDamage;
        
        private Enemy _enemy;
        private readonly DamageCalculator _damageCalculator = new DamageCalculator();
        
        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _enemy.AttackBehaviour.OnAttackBase += Dead;
        }

        public void TakeDamage(int damage, DamageType damageType)
        {
            if (_enemy.CharacteristicsEnemy.IsDeath)
            {
                return;
            }
            
            var calculatedDamage = _damageCalculator.GetCalculatedDamage(_enemy.CharacteristicsEnemy, damageType, damage);
            _enemy.CharacteristicsEnemy.CurrentHp -= calculatedDamage;
            OnReceivedDamage?.Invoke();
            
            if (_enemy.CharacteristicsEnemy.CurrentHp <= 0)
            {
                _enemy.CharacteristicsEnemy.IsDeath = true;
                _enemy.EnemyAnimationController.SetAnimationDead();
            }
        }
        
        public void RestoreHealth(int recovery)
        {
            if (!_enemy.CharacteristicsEnemy.IsDeath)
            {
                _enemy.CharacteristicsEnemy.CurrentHp += recovery;
            }
        }
        
        private void Dead()
        {
            _enemy.CharacteristicsEnemy.IsDeath = true;
            OnDead?.Invoke(_enemy);
            EventStreams.UserInterface.Publish(new EnemyDestroyedEvent(_enemy));
        }
        
        private void OnDestroy()
        {
            if (_enemy != null)
            {
                _enemy.AttackBehaviour.OnAttackBase -= Dead;
            }
        }
    }
}
