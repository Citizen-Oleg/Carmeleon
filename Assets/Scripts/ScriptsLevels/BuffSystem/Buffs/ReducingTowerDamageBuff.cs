using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Пассивное уменьшение урона башен
    /// </summary>
    public class ReducingTowerDamageBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Tower _tower;
        private readonly float _reductionPercentage;
        
        public ReducingTowerDamageBuff(Tower tower, float reductionPercentage)
        {
            _tower = tower;
            _reductionPercentage = reductionPercentage;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.PercentageDamageReduction += _reductionPercentage;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.PercentageDamageReduction -= _reductionPercentage;
        }
    }
}