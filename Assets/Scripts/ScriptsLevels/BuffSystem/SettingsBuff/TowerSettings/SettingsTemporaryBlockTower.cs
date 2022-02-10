using BuffSystem.Buffs;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff/TemporaryBlockTower", order = 6)]
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