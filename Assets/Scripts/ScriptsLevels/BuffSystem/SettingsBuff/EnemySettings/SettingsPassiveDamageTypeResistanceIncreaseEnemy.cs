using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/IncreaseResistanceDamageType", order = 14)]
    public class SettingsPassiveDamageTypeResistanceIncreaseEnemy : SettingsBuff<Enemy>
    {
        [SerializeField]
        private DamageType damageType;
        [Range(0, 100)]
        [SerializeField]
        private int percentageReduction;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new PassiveDamageTypeResistanceIncrease(buffObject, damageType, percentageReduction);
        }
    }
}