using EnemyComponent;
using Interface;
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerCharacteristics))]
    public class RangeAttackBehavior : MonoBehaviour, IAttackBehaviour
    {
        public bool IsCooldown => _lastShotTime + _towerCharacteristics.AttackSpeed > Time.time;
        
        [SerializeField]
        private Projectile _prefabProjectile;
    
        private float _lastShotTime;

        private TowerCharacteristics _towerCharacteristics;

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
            var projectile = Instantiate(_prefabProjectile, transform.position, quaternion.identity);
            projectile.Initialize(_towerCharacteristics.Damage, enemy, projectile1 => Destroy(projectile.gameObject),
                _towerCharacteristics.DamageType);
        }
    }
}