using EnemyComponent;
using Factory;
using Interface;
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
        private ProjectileFactory _projectileFactory;
        
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

        public void Attack(Enemy enemy)
        {
            _lastShotTime = Time.time;
            var product = _projectileFactory.GetProduct(_prefabProjectile);
            
            if (product is Projectile projectile)
            {
                projectile.transform.position = transform.position;
                projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);
            }
        }

        private void Callback(Projectile projectile)
        {
            _projectileFactory.ReleaseProduct(projectile);
        }
    }
}