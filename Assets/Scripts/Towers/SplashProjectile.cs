using System;
using EnemyComponent;
using ManagerHB;
using UnityEngine;

namespace Towers
{
    public class SplashProjectile : Projectile
    {
        [SerializeField]
        private float _explosionRadius;

        private Collider2D[] _colliders2D;
        
        protected override void ApplyDamage()
        {
            _colliders2D = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
            foreach (var collider in _colliders2D)
            {
                if (collider.CompareTag("Enemy") && collider.TryGetComponent(out HealthBehavior healthBehavior))
                {
                    healthBehavior.TakeDamage(_damage, _damageType);
                }
            }
            
            _callback?.Invoke(this);
            _target = null;
        }
        
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }
    }
}