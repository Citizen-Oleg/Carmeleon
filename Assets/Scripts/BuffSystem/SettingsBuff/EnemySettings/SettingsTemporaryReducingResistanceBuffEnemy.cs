using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/TemporaryReducingResistance", order = 2)]
    public class SettingsTemporaryReducingResistanceBuffEnemy : SettingsBuff<Enemy>
    {
        [SerializeField]
        private int _increaseResistance;
        [SerializeField]
        private float _timeOfAction;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new TemporaryReducingResistanceBuff(buffObject, _increaseResistance, _timeOfAction);
        }
    }
}