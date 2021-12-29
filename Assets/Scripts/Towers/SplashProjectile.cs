using DefaultNamespace;
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

        private Collider2D[] _colliders2D = new Collider2D[30];
        
        protected override void ApplyDamage()
        {
            Physics2D.OverlapCircleNonAlloc(transform.position, _explosionRadius, _colliders2D);
            foreach (var collider in _colliders2D)
            {
                if (collider == null)
                {
                    break;
                }
                if (collider.TryGetComponent(out Enemy enemy))
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