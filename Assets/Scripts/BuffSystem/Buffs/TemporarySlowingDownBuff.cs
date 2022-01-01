using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Временное замедление врагов.
    /// </summary>
    public class TemporarySlowingDownBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly Enemy _enemy;
        private readonly float _reductionPercentage;
        private readonly float _duration;
        
        private float _startTime;

        public TemporarySlowingDownBuff(Enemy enemy, float duration, float reductionPercentage)
        {
            _enemy = enemy;
            _duration = duration;
            _reductionPercentage = reductionPercentage;
        }
        
        public void Start()
        {
            IsActive = true;

            _startTime = Time.time;
            _enemy.CharacteristicsEnemy.PercentageSpeedReduction += _reductionPercentage;
        }

        public void Stop()
        {
            IsActive = false;
            _enemy.CharacteristicsEnemy.PercentageSpeedReduction -= _reductionPercentage;
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
    }
}