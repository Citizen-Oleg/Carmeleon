using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/DamageTypeImmunity", order = 7)]
    public class SettingsPassiveIncreasedResistanceBuff : SettingsBuff<Enemy>
    {
        [Range(0, 100)]
        [SerializeField]
        private int _reducedArmorNumber;
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new IncreasedResistanceBuff(buffObject, _reducedArmorNumber);
        }
    }
}