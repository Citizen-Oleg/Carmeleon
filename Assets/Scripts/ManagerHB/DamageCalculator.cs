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
                    return damage - (int)(characteristicsEnemy.Armor / 100f * damage);
                case DamageType.Fire:
                    return damage - (int)(characteristicsEnemy.FireResistance / 100f * damage);
                case DamageType.Air:
                    return damage - (int)(characteristicsEnemy.AirResistance / 100f * damage);
                case DamageType.Earth:
                    return damage - (int)(characteristicsEnemy.EarthResistance / 100f * damage);
                case DamageType.Water:
                    return damage - (int)(characteristicsEnemy.WaterResistance / 100f * damage);
                case DamageType.Clean:
                    return damage;
                default:
                    return damage - (int)(characteristicsEnemy.Armor / 100f * damage);
            }
        }
    }
}