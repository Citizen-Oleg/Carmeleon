using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/Arson", order = 1)]
    public class SettingsArsonBuffEnemy : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _timeOfAction;
        [SerializeField]
        private float _tickTime;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private DamageType _damageType;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new ArsonBuff(buffObject, _timeOfAction, _tickTime, _damage, _damageType);
        }
    }
}