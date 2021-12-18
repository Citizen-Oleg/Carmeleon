using System;
using EnemyComponent;
using UnityEngine;

namespace Towers
{
    public class Projectile : MonoBehaviour
    {
        private const float DISTANCE_TO_TARGET = 0.1f;
        
        [SerializeField]
        protected float _flightSpeed;
        
        protected Enemy _target;
        protected Action<Projectile> _callback;
        protected DamageType _damageType;
        protected int _damage;

        public void Initialize(int damage, Enemy target, Action<Projectile> callback, DamageType damageType = DamageType.Physical)
        {
            _target = target;
            _callback = callback;
            _damage = damage;
            _damageType = damageType;
        }

        private void Update()
        {
            if (_target != null)
            {
                MoveToTarget();    
            }
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position,
                _flightSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target.transform.position) < DISTANCE_TO_TARGET)
            {
                ApplyDamage();
            }
        }

        protected virtual void ApplyDamage()
        {
            _target.HealthBehavior.TakeDamage(_damage, _damageType);
            _callback?.Invoke(this);
            _target = null;
        }
    }
}