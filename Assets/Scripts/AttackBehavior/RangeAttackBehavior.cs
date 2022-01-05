using System.Runtime.CompilerServices;
using EnemyComponent;
using Factory;
using Interface;
using Level;
using Towers;
using UnityEngine;

namespace AttackBehavior
{
    [RequireComponent(typeof(TowerCharacteristics))]
    public class RangeAttackBehavior : MonoBehaviour, IAttackBehaviour
    {
        public bool IsCooldown => _lastShotTime + _towerCharacteristics.AttackSpeed > Time.time;

        [SerializeField]
        protected Projectile _prefabProjectile;
    
        protected float _lastShotTime;

        protected TowerCharacteristics _towerCharacteristics;
        protected ProjectileFactory _projectileFactory;
        
        private void Awake()
        {
            _projectileFactory = LevelManager.ProjectileFactory;
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }
        
        public bool CanAttack(Enemy enemy)
        {
            var isEnemyDead = enemy == null || enemy.CharacteristicsEnemy.IsDeath;
            var targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
            var isAttackDistance = targetDistance <= _towerCharacteristics.AttackRadius;

            return !isEnemyDead && isAttackDistance;
        }

        public virtual void Attack(Enemy enemy)
        {
            _lastShotTime = Time.time;
            var product = _projectileFactory.GetProduct(_prefabProjectile);
            
            if (product is Projectile projectile)
            {
                projectile.transform.position = transform.position;
                projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);
            }
        }

        protected void Callback(Projectile projectile)
        {
            _projectileFactory.ReleaseProduct(projectile);
        }
    }
}