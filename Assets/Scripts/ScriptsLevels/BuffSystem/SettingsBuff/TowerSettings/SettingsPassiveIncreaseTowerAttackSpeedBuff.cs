using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/IncreaseTowerAttackSpeed", order = 1)]
    public class SettingsPassiveIncreaseTowerAttackSpeedBuff : SettingsBuff<Tower>
    {
        [Range(0f, 100f)]
        [SerializeField]
        private float _increasePercentage;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new IncreaseTowerAttackSpeedBuff(buffObject, _increasePercentage);
        }
    }
}