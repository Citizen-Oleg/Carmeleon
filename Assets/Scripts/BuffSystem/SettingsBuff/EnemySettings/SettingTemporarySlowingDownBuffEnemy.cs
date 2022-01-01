using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/TemporarySlowingDown", order = 5)]
    public class SettingTemporarySlowingDownBuffEnemy : SettingsBuff<Enemy>
    {
        [SerializeField]
        private float _duration;
        [Range(0f, 100f)]
        [SerializeField]
        private float _reductionPercentage;
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new TemporarySlowingDownBuff(buffObject, _duration, _reductionPercentage);
        }
    }
}