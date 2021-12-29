using BuffSystem.Buffs;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/SlowingDownEnemy", order = 0)]
    public class SlowingDownBuffEnemy : SettingsBuff<Enemy>
    {
        [Range(0f, 100f)]
        [SerializeField]
        private float _reductionPercentage;
        
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return new SlowingDownBuff(buffObject, _reductionPercentage);
        }
    }
}