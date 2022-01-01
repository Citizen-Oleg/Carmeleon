using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/IncreaseDamage", order = 4)]
    public class SettingsPassiveIncreaseDamageBuff : SettingsBuff<Tower>
    {
        [Range(0, 100)]
        [SerializeField]
        private float _increasePercentage;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new IncreasedDamageBuff(buffObject, _increasePercentage);
        }
    }
}