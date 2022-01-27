using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/RampantRecovery", order = 13)]
    public class SettingsTemporaryRampantRecoveryBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private int _amountHealthRecovery;
        [Range(0, 100)]
        [SerializeField]
        private int _resistanceIncreasePercentage;
        [SerializeField]
        private float _resistanceDuration;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new RampantRecovery(buffObject, _amountHealthRecovery, _resistanceIncreasePercentage,
                _resistanceDuration);
        }
    }
}