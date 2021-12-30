using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class StackingPoisoningBuff : IStackingBuff, ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _timeOfAction > Time.time;
        
        private readonly float _timeOfAction;
        private readonly DamageType _damageType;
        private readonly int _damage;
        private readonly int _maxStack;
        private readonly Enemy _enemy;
        
        private int _currentStack;
        private float _startTime;

        public StackingPoisoningBuff(Enemy enemy, int damage, DamageType damageType, int maxStack, float timeOfAction)
        {
            _enemy = enemy;
            _damage = damage;
            _damageType = damageType;
            _maxStack = maxStack;
            _timeOfAction = timeOfAction;
        }
        
        public void Start()
        {
            IsActive = true;
            _currentStack = 1;
            _startTime = Time.time;
            
            ApplyDamage();
        }

        public void Stop()
        {
            IsActive = false;
            _currentStack = 0;
        }

        public void AddStack()
        {
            if (_currentStack == _maxStack)
            {
                Refresh();
            }
            else
            {
                _currentStack++;
            }

            ApplyDamage();
        }

        public void Update()
        {
            if (!_hasTimeAction)
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