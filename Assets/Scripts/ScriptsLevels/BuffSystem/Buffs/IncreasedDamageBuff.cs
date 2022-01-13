using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Бафф повышающий урон башни
    /// </summary>
    public class IncreasedDamageBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }
        
        private readonly Tower _tower;
        private readonly float _increasePercentage;

        public IncreasedDamageBuff(Tower tower, float increasePercentage)
        {
            _tower = tower;
            _increasePercentage = increasePercentage;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.PercentageIncreaseDamage += _increasePercentage;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.PercentageIncreaseDamage -= _increasePercentage;
        }
    }
}