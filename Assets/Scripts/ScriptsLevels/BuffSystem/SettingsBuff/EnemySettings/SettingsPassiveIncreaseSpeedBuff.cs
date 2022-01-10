using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/IncreaseSpeed", order = 8)]
    public class SettingsPassiveIncreaseSpeedBuff : SettingsBuff<Enemy>
    {
        [Range(0f, 100f)]
        [SerializeField]
        private float _percentageIncreaseSpeed;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new PassiveIncreaseSpeedBuff(buffObject, _percentageIncreaseSpeed);
        }
    }
}