using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/SpoilageBuff", order = 10)]
    public class SettingsStackingSpoilageBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private float _duration;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new StackingSpoilageBuff(buffObject, _damage, _damageType, _duration);
        }
    }
}