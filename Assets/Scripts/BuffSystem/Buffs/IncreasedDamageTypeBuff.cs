using EnemyComponent;
using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    public class IncreasedDamageTypeBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Tower _tower;
        private readonly float _increasePercentage;
        private readonly DamageType _damageType;
        
        public IncreasedDamageTypeBuff(Tower tower, float increasePercentage, DamageType damageType)
        {
            _tower = tower;
            _increasePercentage = increasePercentage;
            _damageType = damageType;
        }
        
        public void Start()
        {
            IsActive = true;

            if (_tower.TowerCharacteristics.DamageType == _damageType)
            {
                _tower.TowerCharacteristics.PercentageIncreaseDamage += _increasePercentage;
            }
        }

        public void Stop()
        {
            IsActive = false;
            
            if (_tower.TowerCharacteristics.DamageType == _damageType)
            {
                _tower.TowerCharacteristics.PercentageIncreaseDamage -= _increasePercentage;
            }
        }
    }
}