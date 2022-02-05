using EnemyComponent;
using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    public class PassiveDamageTypeResistanceIncrease : IPassiveBuff
    {
        private readonly Enemy _enemy;
        private readonly DamageType _damageType;
        private readonly int _percentageReduction;
        
        public PassiveDamageTypeResistanceIncrease(Enemy enemy, DamageType damageType, int percentageReduction)
        {
            _enemy = enemy;
            _damageType = damageType;
            _percentageReduction = percentageReduction;
        }

        public bool IsActive { get; private set; }
        
        public void Start()
        {
            IsActive = true;
            SetPercentageReduction();
        }

        public void Stop()
        {
            IsActive = false;
            SetPercentageReduction();
        }

        private void SetPercentageReduction()
        {
            switch (_damageType)
            {
                case DamageType.Physical:
                    _enemy.CharacteristicsEnemy.Armor += IsActive ? _percentageReduction : -_percentageReduction;
                     break;
                case DamageType.Fire:
                    _enemy.CharacteristicsEnemy.FireResistance += IsActive ? _percentageReduction : -_percentageReduction;
                     break;
                case DamageType.Air:
                    _enemy.CharacteristicsEnemy.AirResistance += IsActive ? _percentageReduction : -_percentageReduction;
                     break;
                case DamageType.Earth:
                    _enemy.CharacteristicsEnemy.EarthResistance += IsActive ? _percentageReduction : -_percentageReduction;
                     break;
                case DamageType.Water:
                    _enemy.CharacteristicsEnemy.WaterResistance += IsActive ? _percentageReduction : -_percentageReduction;
                     break;
            }
        }
    }
}