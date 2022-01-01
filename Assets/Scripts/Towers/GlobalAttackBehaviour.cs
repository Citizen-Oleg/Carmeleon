using System;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{ 
    public class GlobalAttackBehaviour : MonoBehaviour, IAttackBehaviour
    {
        public bool IsCooldown => _lastShotTime + _towerCharacteristics.AttackSpeed > Time.time;
        
        private TowerCharacteristics _towerCharacteristics;
        private float _lastShotTime;

        private void Awake()
        {
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }
        
        public virtual bool CanAttack(Enemy enemy)
        {
            var isEnemyDead = enemy == null || enemy.CharacteristicsEnemy.IsDeath;
            return !isEnemyDead;
        }

        public virtual void Attack(Enemy enemy)
        {
            _lastShotTime = Time.time;
            enemy.HealthBehavior.TakeDamage(_towerCharacteristics.Damage, _towerCharacteristics.DamageType);
        }
    }
}