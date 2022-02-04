using System;
using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Projectile : MonoBehaviour, IProduct
    {
        private const float DISTANCE_TO_TARGET = 0.25f;
        
        public float FlightSpeed
        {
            get => _flightSpeed;
            set => _flightSpeed = value;
        }
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public int ID => _id;
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private float _flightSpeed;
        
        protected Enemy _target;
        protected Action<Projectile> _callback;
        protected DamageType _damageType;
        protected int _damage;
        private SettingsBuff<Enemy> _settingsBuff;

        public void Initialize(int damage, Enemy target, Action<Projectile> callback,
            DamageType damageType = DamageType.Physical, SettingsBuff<Enemy> settingsBuff = null)
        {
            _target = target;
            _callback = callback;
            _damage = damage;
            _damageType = damageType;
            _settingsBuff = settingsBuff;
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
        
        protected virtual void ApplyDamage()
        {
            _target.HealthBehavior.TakeDamage(_damage, _damageType);
            ApplyBuffEnemy(_target);
            _callback?.Invoke(this);
            _target = null;
        }
        
        protected void ApplyBuffEnemy(Enemy enemy)
        {
            if (_settingsBuff != null)
            {
                enemy.EnemyBuffController.AddBuff(_settingsBuff);
            }
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.PositionBody.position,
                _flightSpeed * Time.deltaTime);

            transform.right = (Vector2) (_target.transform.position - transform.position);

            if (Vector2.Distance(transform.position, _target.PositionBody.position) < DISTANCE_TO_TARGET)
            {
                ApplyDamage();
            }
        }
    }
}