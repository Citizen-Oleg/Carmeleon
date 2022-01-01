using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Поджигание - наносит урон в течении _duration, каждые _tickTime.
    /// </summary>
    public class ArsonBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        private bool _isTickTime => _lastTickTime + _tickTime < Time.time;

        private Enemy _enemy;
        
        private float _startTime;
        private readonly float _duration;

        private float _lastTickTime;
        private readonly float _tickTime;

        private readonly int _damage;
        private readonly DamageType _damageType;


        public ArsonBuff(Enemy enemy, float duration, float tickTime, int damage, DamageType damageType)
        {
            _enemy = enemy;
            _duration = duration;
            _tickTime = tickTime;
            _damage = damage;
            _damageType = damageType;
        }
        
        public void Start()
        {
            IsActive = true;
            
            _startTime = Time.time;
        }

        public void Stop()
        {
            IsActive = false;
        }

        public void Update()
        {
            if (_hasTimeAction)
            {
                if (_isTickTime)
                {
                    _lastTickTime = Time.time;
                    _enemy.HealthBehavior.TakeDamage(_damage, _damageType);
                }
            }
            else
            {
                Stop();
            }
        }

        public void Refresh()
        {
            _startTime = Time.time;
            _lastTickTime = Time.time;
        }
    }
}