using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/Frostbite", order = 11)]
    public class SettingsFrostbiteBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _frostbiteDuration;
        [SerializeField]
        private int _maxStack;
        [SerializeField]
        private SettingsTemporaryFreezingBuff _settingsTemporaryFreezingBuff;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new FrostbiteBuff(buffObject, _frostbiteDuration, _maxStack, _settingsTemporaryFreezingBuff);
        }
    }
}