using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff.EnemySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/RobberyBuff", order = 12)]
    public class SettingsTemporaryRobberyBuff : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _duration;
        [SerializeField]
        private float _increasedChance;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new RobberyBuff(buffObject, _duration, _increasedChance);
        }
    }
}