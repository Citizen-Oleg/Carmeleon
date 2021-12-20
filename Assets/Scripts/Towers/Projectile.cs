using System;
using EnemyComponent;
using Factory;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Projectile : MonoBehaviour, IProduct
    {
        private const float DISTANCE_TO_TARGET = 0.1f;
        
        public float FlightSpeed
        {
            get => _flightSpeed;
            set => _flightSpeed = value;
        }
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public int ID => _id;

        [SerializeField]
        protected float _flightSpeed;

        [SerializeField]
        private int _id;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
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
            if (_target.CharacteristicsEnemy.IsDeath)
            {
                _callback?.Invoke(this);
                _target = null;
            }
            
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