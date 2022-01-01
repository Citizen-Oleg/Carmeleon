using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/IncreasedDamageType", order = 3)]
    public class SettingsPassiveIncreasedDamageTypeTower : SettingsBuff<Tower>
    {
        [Range(0, 100)]
        [SerializeField]
        private float _increasePercentage;
        [SerializeField]
        private DamageType _damageType;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new IncreasedDamageTypeBuff(buffObject, _increasePercentage, _damageType);
        }
    }
}