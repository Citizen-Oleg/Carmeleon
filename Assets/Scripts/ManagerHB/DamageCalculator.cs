using EnemyComponent;
using Towers;

namespace ManagerHB
{
    public class DamageCalculator
    {
        public int GetCalculatedDamage(CharacteristicsEnemy characteristicsEnemy, DamageType damageType, int damage)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return damage - characteristicsEnemy.Armor / 100 * damage;
                case DamageType.Fire:
                    return damage - characteristicsEnemy.FireResistance * damage;
                case DamageType.Air:
                    return damage - characteristicsEnemy.AirResistance * damage;
                case DamageType.Earth:
                    return damage - characteristicsEnemy.EarthResistance * damage;
                case DamageType.Water:
                    return damage - characteristicsEnemy.WaterResistance * damage;
                default:
                    return damage - characteristicsEnemy.Armor * damage;
            }
        }
    }
}