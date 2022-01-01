using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Бафф, повышающий скорость атаки (скорость атаки считается как - выстрел раз в N секунд)
    /// </summary>
    public class IncreaseTowerAttackSpeedBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Tower _tower;
        private readonly float _increasePercentage;
        
        public IncreaseTowerAttackSpeedBuff(Tower tower, float increasePercentage)
        {
            _tower = tower;
            _increasePercentage = increasePercentage;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.PercentageIncreaseAttackSpeed += _increasePercentage;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.PercentageIncreaseAttackSpeed -= _increasePercentage;
        }
    }
}