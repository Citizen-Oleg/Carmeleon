using System;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerCharacteristics))]
    public class RadiusAttackBehaviour : MonoBehaviour, IAttackBehaviour
    {
        public bool IsCooldown => _lastShotTime + _towerCharacteristics.AttackSpeed > Time.time;

        private TowerCharacteristics _towerCharacteristics;
        private float _lastShotTime;
        
        private void Awake()
        {
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }

        public bool CanAttack(Enemy enemy)
        {
            var isEnemyDead = enemy == null || enemy.CharacteristicsEnemy.IsDeath;
            var targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
            var isAttackDistance = targetDistance <= _towerCharacteristics.AttackRadius;

            return !isEnemyDead && isAttackDistance;
        }

        public void Attack(Enemy enemy)
        {
            _lastShotTime = Time.time;
            enemy.HealthBehavior.TakeDamage(_towerCharacteristics.Damage, _towerCharacteristics.DamageType);
        }
    }
}