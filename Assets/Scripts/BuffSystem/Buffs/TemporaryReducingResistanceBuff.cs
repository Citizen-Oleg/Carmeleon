using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Временное снижение всех видов сопротивления у врагов (искл. чистый)
    /// </summary>
    public class TemporaryReducingResistanceBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }
        
        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly Enemy _enemy;
        private readonly int _increaseResistance;
        private readonly float _duration;
        
        private float _startTime;

        public TemporaryReducingResistanceBuff(Enemy enemy, int increaseResistance, float duration)
        {
            _enemy = enemy;
            _increaseResistance = increaseResistance;
            _duration = duration;
        }
        
        public void Start()
        {
            IsActive = true;
            _startTime = Time.time;

            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor -= _increaseResistance;
            characteristics.AirResistance -= _increaseResistance;
            characteristics.EarthResistance -= _increaseResistance;
            characteristics.FireResistance -= _increaseResistance;
            characteristics.WaterResistance -= _increaseResistance;
        }

        public void Stop()
        {
            IsActive = false;
            
            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor += _increaseResistance;
            characteristics.AirResistance += _increaseResistance;
            characteristics.EarthResistance += _increaseResistance;
            characteristics.FireResistance += _increaseResistance;
            characteristics.WaterResistance += _increaseResistance;
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