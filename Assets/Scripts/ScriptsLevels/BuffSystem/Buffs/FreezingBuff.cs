using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Бафф замораживающий врага на _freezeDuration времени
    /// </summary>
    public class FreezingBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }
        
        private bool _hasFreezeAction => _startFreezeTime + _freezeDuration > Time.time;
        
        private readonly Enemy _enemy;
        private readonly float _freezeDuration;

        private float _startFreezeTime;

        public FreezingBuff(Enemy enemy, float freezeDuration)
        {
            _enemy = enemy;
            _freezeDuration = freezeDuration;
        }

        ~FreezingBuff()
        {
            _enemy.HealthBehavior.OnTakeDamage -= Stop;
        }
        
        public void Start()
        {
            IsActive = true;
            Refresh();
            _enemy.CharacteristicsEnemy.IsFrozen = true;
            _enemy.HealthBehavior.OnTakeDamage += Stop;
        }

        public void Stop()
        {
            IsActive = false;
            _enemy.CharacteristicsEnemy.IsFrozen = false;
        }
        
        public void Update()
        {
            if (!_hasFreezeAction)
            {
                Stop();
            }
        }
        
        public void Refresh()
        {
            _startFreezeTime = Time.time;
        }
    }
}