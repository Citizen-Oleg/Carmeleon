using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/DamageTypeImmunity", order = 6)]
    public class SettingsPassiveDamageTypeImmunityBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private DamageType _immunityDamageType;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new DamageTypeImmunity(buffObject, _immunityDamageType);
        }
    }
}