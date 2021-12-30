using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/TowersBuff", order = 0)]
    public class SettingsBuffTower : SettingsBuff<Tower>
    {
        public override IPassiveBuff GetBuff(Tower buffObject)
        {
            return null;
        }
    }
}