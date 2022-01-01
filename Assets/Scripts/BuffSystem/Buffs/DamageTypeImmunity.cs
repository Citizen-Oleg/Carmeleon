using EnemyComponent;
using Interface;
using Towers;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Бафф дающий иммунитет к урону
    /// </summary>
    public class DamageTypeImmunity : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Enemy _enemy;
        private readonly DamageType _damageType;

        public DamageTypeImmunity(Enemy enemy, DamageType damageType)
        {
            _enemy = enemy;
            _damageType = damageType;
        }
        
        public void Start()
        {
            IsActive = true;
            SetImmunity(true);
        }

        public void Stop()
        {
            IsActive = false;
            SetImmunity(false);
        }

        private void SetImmunity(bool hasImmunity)
        {
            switch (_damageType)
            {
                case DamageType.Air:
                    _enemy.CharacteristicsEnemy.HasImmunityAir = hasImmunity;
                    break;
                case DamageType.Earth:
                    _enemy.CharacteristicsEnemy.HasImmunityEarth = hasImmunity;
                    break;
                case DamageType.Fire:
                    _enemy.CharacteristicsEnemy.HasImmunityFire = hasImmunity;
                    break;
                case DamageType.Physical:
                    _enemy.CharacteristicsEnemy.HasImmunityPhysical = hasImmunity;
                    break;
                case  DamageType.Water:
                    _enemy.CharacteristicsEnemy.HasImmunityWater = hasImmunity;
                    break;
            }
        }
    }
}