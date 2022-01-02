using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Порча - урон * кол-во стаков наносится при накладывании эффекта
    /// </summary>
    public class StackingSpoilageBuff : IStackingBuff, ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly float _duration;
        private readonly DamageType _damageType;
        private readonly int _damage;
        private readonly Enemy _enemy;
        
        private int _currentStack;
        private float _startTime;

        public StackingSpoilageBuff(Enemy enemy, int damage, DamageType damageType, float duration)
        {
            _enemy = enemy;
            _damage = damage;
            _damageType = damageType;
            _duration = duration;
        }
        
        public void Start()
        {
            IsActive = true;
            AddStack();
        }

        public void Stop()
        {
            IsActive = false;
            _currentStack = 0;
        }

        public void AddStack()
        {
            _currentStack++;
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