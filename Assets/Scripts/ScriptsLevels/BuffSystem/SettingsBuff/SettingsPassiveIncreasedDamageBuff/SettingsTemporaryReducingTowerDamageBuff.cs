using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/TemporaryReducingTowerDamage", order = 5)]
    public class SettingsTemporaryReducingTowerDamageBuff : SettingsBuff<Tower>
    {
        [SerializeField]
        private float _reductionPercentage;
        [SerializeField]
        private float _duration;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new TemporaryReducingTowerDamageBuff(buffObject, _reductionPercentage, _duration);
        }
    }
}