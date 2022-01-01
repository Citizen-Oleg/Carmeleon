using EnemyComponent;
using Interface;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Пассивный бафф повышающий скорость врагов
    /// </summary>
    public class PassiveIncreaseSpeedBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Enemy _enemy;
        private readonly float _percentageIncreaseSpeed; 
        
        public PassiveIncreaseSpeedBuff(Enemy enemy, float percentageIncreaseSpeed)
        {
            _enemy = enemy;
            _percentageIncreaseSpeed = percentageIncreaseSpeed;
        }
        
        public void Start()
        {
            IsActive = true;
            _enemy.CharacteristicsEnemy.PercentageIncreaseSpeed += _percentageIncreaseSpeed;
        }

        public void Stop()
        {
            IsActive = false;
            _enemy.CharacteristicsEnemy.PercentageIncreaseSpeed -= _percentageIncreaseSpeed;
        }
    }
}