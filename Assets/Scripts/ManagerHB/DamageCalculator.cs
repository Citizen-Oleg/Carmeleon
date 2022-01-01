using EnemyComponent;
using Towers;

namespace ManagerHB
{
    public class DamageCalculator
    {
        private const int FROZEN_TARGET_FIRE_MULTIPLIER = 3;
        private const int FROZEN_TARGET_MULTIPLIER = 2;
        
        public int GetCalculatedDamage(CharacteristicsEnemy characteristicsEnemy, DamageType damageType, int damage)
        {
            damage = CheckFrozenTarget(characteristicsEnemy, damageType, damage);
            switch (damageType)
            {
                case DamageType.Physical:
                    if (characteristicsEnemy.HasImmunityPhysical)
                    {
                        return 0;
                    }
                    
                    return damage - (int)(characteristicsEnemy.Armor / 100f * damage);
                case DamageType.Fire:
                    if (characteristicsEnemy.HasImmunityFire)
                    {
                        return 0;
                    }
                    
                    return damage - (int)(characteristicsEnemy.FireResistance / 100f * damage);
                case DamageType.Air:
                    if (characteristicsEnemy.HasImmunityAir)
                    {
                        return 0;
                    }
                    
                    return damage - (int)(characteristicsEnemy.AirResistance / 100f * damage);
                case DamageType.Earth:
                    if (characteristicsEnemy.HasImmunityEarth)
                    {
                        return 0;
                    }
                    
                    return damage - (int)(characteristicsEnemy.EarthResistance / 100f * damage);
                case DamageType.Water:
                    if (characteristicsEnemy.HasImmunityWater)
                    {
                        return 0;
                    }
                    
                    return damage - (int)(characteristicsEnemy.WaterResistance / 100f * damage);
                case DamageType.Clean:
                    return damage;
                default:
                    return damage - (int)(characteristicsEnemy.Armor / 100f * damage);
            }
        }

        private int CheckFrozenTarget(CharacteristicsEnemy characteristicsEnemy, DamageType damageType, int damage)
        {
            if (characteristicsEnemy.IsFrozen)
            {
                if (damageType == DamageType.Fire)
                {
                    return damage * FROZEN_TARGET_FIRE_MULTIPLIER;
                }
                
                return damage * FROZEN_TARGET_MULTIPLIER;
            }

            return damage;
        }
    }
}