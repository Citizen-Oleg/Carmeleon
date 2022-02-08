using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    public class SettingsTemporaryBlockTower : SettingsBuff<Tower>
    {
        [SerializeField]
        private float _duration;
        
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return new TemporaryBlockTowerBuff(buffObject, _duration);
        }
    }
}