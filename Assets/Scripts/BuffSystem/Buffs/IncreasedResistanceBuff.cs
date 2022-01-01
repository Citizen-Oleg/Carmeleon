using EnemyComponent;
using Interface;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Бафф, повышающий сопротивление урону
    /// </summary>
    public class IncreasedResistanceBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Enemy _enemy;
        private readonly int _reducedArmorNumber;

        public IncreasedResistanceBuff(Enemy enemy, int reducedArmorNumber)
        {
            _enemy = enemy;
            _reducedArmorNumber = reducedArmorNumber;
        }
        
        public void Start()
        {
            IsActive = true;
            
            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor += _reducedArmorNumber;
            characteristics.AirResistance += _reducedArmorNumber;
            characteristics.EarthResistance += _reducedArmorNumber;
            characteristics.FireResistance += _reducedArmorNumber;
            characteristics.WaterResistance += _reducedArmorNumber;
        }

        public void Stop()
        {
            IsActive = false;
            
            var characteristics = _enemy.CharacteristicsEnemy;

            characteristics.Armor -= _reducedArmorNumber;
            characteristics.AirResistance -= _reducedArmorNumber;
            characteristics.EarthResistance -= _reducedArmorNumber;
            characteristics.FireResistance -= _reducedArmorNumber;
            characteristics.WaterResistance -= _reducedArmorNumber;
        }
    }
}