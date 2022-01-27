using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class RampantRecovery : ITemporaryBuff
    {
        public bool IsActive { get; set; }

        private bool _hasResistanceAction => _startTime + _resistanceDuration > Time.time; 
        
        private readonly Enemy _enemy;
        private readonly int _amountHealthRecovery;
        private readonly int _resistanceIncreasePercentage;
        private readonly float _resistanceDuration;

        private float _startTime;

        public RampantRecovery(Enemy enemy, int amountHealthRecovery, int resistanceIncreasePercentage, float resistanceDuration)
        {
            _enemy = enemy;
            _amountHealthRecovery = amountHealthRecovery;
            _resistanceIncreasePercentage = resistanceIncreasePercentage;
            _resistanceDuration = resistanceDuration;
        }
        
        public void Start()
        {
            IsActive = true;
            Refresh();

            _enemy.CharacteristicsEnemy.Armor += _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.FireResistance += _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.EarthResistance += _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.WaterResistance += _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.AirResistance += _resistanceIncreasePercentage;
        }

        public void Stop()
        {
            IsActive = false;
            
            _enemy.CharacteristicsEnemy.Armor -= _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.FireResistance -= _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.EarthResistance -= _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.WaterResistance -= _resistanceIncreasePercentage;
            _enemy.CharacteristicsEnemy.AirResistance -= _resistanceIncreasePercentage;
        }

        public void Update()
        {
            if (!_hasResistanceAction)
            {
                Stop();
            }
        }

        public void Refresh()
        {
            _startTime = Time.time;
            _enemy.HealthBehavior.RestoreHealth(_amountHealthRecovery);
        }
    }
}