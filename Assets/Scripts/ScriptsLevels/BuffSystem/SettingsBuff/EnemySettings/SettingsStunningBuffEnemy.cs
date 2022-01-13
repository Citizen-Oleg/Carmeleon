using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/StunningEnemy", order = 4)]
    public class SettingsStunningBuffEnemy : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _duration;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new StunningBuff(buffObject, _duration);
        }
    }
}