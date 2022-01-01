using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/Freezing", order = 9)]
    public class SettingsTemporaryFreezingBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _freezeDuration;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new FreezingBuff(buffObject, _freezeDuration); 
        }
    }
}