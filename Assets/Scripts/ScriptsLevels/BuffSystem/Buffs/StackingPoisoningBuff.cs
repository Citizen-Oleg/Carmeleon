using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Отравление - наносит урон * _currentStack раз в тик, если время действия закончится то стаки скидываются.
    /// </summary>
    public class StackingPoisoningBuff : IStackingBuff, ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        private bool _hasTimeTick => _startTimeTick + _tickTime > Time.time;
        
        private readonly float _duration;
        private readonly DamageType _damageType;
        private readonly int _damage;
        private readonly int _maxStack;
        private readonly Enemy _enemy;
        private readonly float _tickTime;
        
        private int _currentStack;
        
        private float _startTime;
        private float _startTimeTick;

        public StackingPoisoningBuff(Enemy enemy, int damage, DamageType damageType, int maxStack, float duration, float tickTime)
        {
            _enemy = enemy;
            _damage = damage;
            _damageType = damageType;
            _maxStack = maxStack;
            _duration = duration;
            _tickTime = tickTime;
        }
        
        public void Start()
        {
            IsActive = true;
            AddStack();
            Refresh();
        }

        public void Stop()
        {
            IsActive = false;
            _currentStack = 0;
        }

        public void AddStack()
        {
            if (_maxStack != _currentStack)
            {
                _currentStack++;
            }
        }

        public void Update()
        {
            if (_hasTimeAction)
            {
                if (!_hasTimeTick)
                {
                    ApplyDamage();
                    _startTimeTick = Time.time;
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
        }
        
        private void ApplyDamage()
        {
            var damage = _currentStack * _damage;
            _enemy.HealthBehavior.TakeDamage(damage, _damageType);
        }
    }
}