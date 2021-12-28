using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff", order = 0)]
    public class SettingsBuffEnemy : SettingsBuff<Enemy>
    {
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return null;
        }
    }
}