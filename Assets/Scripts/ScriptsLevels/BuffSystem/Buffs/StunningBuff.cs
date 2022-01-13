using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Стан - останавливает врага на _duration
    /// </summary>
    public class StunningBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly Enemy _enemy;
        private readonly float _duration;

        private float _startTime;
        
        public StunningBuff(Enemy enemy, float duration)
        {
            _enemy = enemy;
            _duration = duration;
        }
        
        public void Start()
        {
            IsActive = true;
            _startTime = Time.time;
            _enemy.CharacteristicsEnemy.IsMoving = false;
        }

        public void Stop()
        {
            IsActive = false;
            _enemy.CharacteristicsEnemy.IsMoving = true;
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