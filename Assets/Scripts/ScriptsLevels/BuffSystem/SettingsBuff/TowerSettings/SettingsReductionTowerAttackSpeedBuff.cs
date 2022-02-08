using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/ReductionTowerAttackSpeed", order = 2)]
    public class SettingsReductionTowerAttackSpeedBuff : SettingsBuff<Tower>
    {
        [Range(0, 100)]
        [SerializeField]
        private float _reductionPercentage;
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new ReductionTowerAttackSpeedBuff(buffObject, _reductionPercentage);
        }
    }
}