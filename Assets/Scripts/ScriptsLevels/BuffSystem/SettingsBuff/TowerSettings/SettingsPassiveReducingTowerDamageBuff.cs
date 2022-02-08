using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/ReducingTowerDamage", order = 0)]
    public class SettingsPassiveReducingTowerDamageBuff : SettingsBuff<Tower>
    {
        [Range(0f, 100f)]
        [SerializeField]
        private float _reductionPercentage;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new ReducingTowerDamageBuff(buffObject, _reductionPercentage);
        }
    }
}