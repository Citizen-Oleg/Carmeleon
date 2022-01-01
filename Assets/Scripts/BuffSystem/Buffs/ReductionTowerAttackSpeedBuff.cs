using EnemyComponent;
using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Снижение скорости атаки башен. (скорость атаки считается как - выстрел раз в N секунд)
    /// </summary>
    public class ReductionTowerAttackSpeedBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Tower _tower;
        private readonly float _reductionPercentage;

        public ReductionTowerAttackSpeedBuff(Tower tower, float reductionPercentage)
        {
            _tower = tower;
            _reductionPercentage = reductionPercentage;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.PercentageAttackSpeedReduction += _reductionPercentage;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.PercentageAttackSpeedReduction -= _reductionPercentage;
        }
    }
}