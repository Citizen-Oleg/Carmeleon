using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/StackingPoisoning", order = 3)]
    public class SettingsStackingPoisoning : SettingsBuff<Enemy>
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private int _maxStack;
        [SerializeField]
        private float _timeOfAction;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new StackingPoisoningBuff(buffObject, _damage, _damageType, _maxStack, _timeOfAction);
        }
    }
}