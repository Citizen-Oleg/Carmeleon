using EnemyComponent;
using ManagerHB;
using UnityEngine;

namespace Towers
{
    public class SplashProjectile : Projectile
    {
        public float ExplosionRadius
        {
            get => _explosionRadius;
            set => _explosionRadius = value;
        }

        [SerializeField]
        private float _explosionRadius;
        [SerializeField]
        private LayerMask _enemyLayer;

        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        
        protected override void ApplyDamage()
        {
            var count = Physics2D.OverlapCircleNonAlloc(transform.position, _explosionRadius, _colliders2D, _enemyLayer);
            
            for (var i = 0; i < count; i++)
            {
                if (_colliders2D[i] == null)
                {
                    break;
                }
                
                if (_colliders2D[i].TryGetComponent(out Enemy enemy))
                {
                    ApplyBuffEnemy(enemy);
                    enemy.HealthBehavior.TakeDamage(_damage, _damageType);
                }
            }
            
            _callback?.Invoke(this);
            _target = null;
        }
    }
}