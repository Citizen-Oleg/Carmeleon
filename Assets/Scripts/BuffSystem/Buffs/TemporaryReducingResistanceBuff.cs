using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class TemporaryReducingResistanceBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }
        
        private bool _hasTimeAction => _startTime + _timeOfAction > Time.time;
        
        private readonly Enemy _enemy;
        private readonly int _reducedArmorNumber;
        private readonly float _timeOfAction;
        
        private float _startTime;

        public TemporaryReducingResistanceBuff(Enemy enemy, int reducedArmorNumber, float timeOfAction)
        {
            _enemy = enemy;
            _reducedArmorNumber = reducedArmorNumber;
            _timeOfAction = timeOfAction;
        }
        
        public void Start()
        {
            IsActive = true;
            _startTime = Time.time;

            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor -= _reducedArmorNumber;
            characteristics.AirResistance -= _reducedArmorNumber;
            characteristics.EarthResistance -= _reducedArmorNumber;
            characteristics.FireResistance -= _reducedArmorNumber;
            characteristics.WaterResistance -= _reducedArmorNumber;
        }

        public void Stop()
        {
            IsActive = false;
            
            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor += _reducedArmorNumber;
            characteristics.AirResistance += _reducedArmorNumber;
            characteristics.EarthResistance += _reducedArmorNumber;
            characteristics.FireResistance += _reducedArmorNumber;
            characteristics.WaterResistance += _reducedArmorNumber;
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