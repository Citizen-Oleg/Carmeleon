using EnemyComponent;
using Factory;
using Interface;
using Level;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Tower))]
    public class RangeAttackBehavior : MonoBehaviour, IAttackBehaviour
    {
        public bool IsCooldown => _lastShotTime + _towerCharacteristics.AttackSpeed > Time.time;

        [SerializeField]
        protected Projectile _prefabProjectile;
        [SerializeField]
        protected Transform _projectileLaunchPosition;
        
        protected float _lastShotTime;

        protected Tower _tower;
        protected TowerCharacteristics _towerCharacteristics;
        protected ProjectileFactory _projectileFactory;
        
        private void Awake()
        {
            _projectileFactory = LevelManager.ProjectileFactory;
            _tower = GetComponent<Tower>();
            _towerCharacteristics = _tower.TowerCharacteristics;
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
            var projectile = GetProjectile();
            
            projectile.transform.position = _projectileLaunchPosition.position;
            projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);
        }

        protected Projectile GetProjectile()
        {
            return _projectileFactory.GetProduct(_prefabProjectile) as Projectile;
        }

        protected void Callback(Projectile projectile)
        {
            _projectileFactory.ReleaseProduct(projectile);
        }
    }
}