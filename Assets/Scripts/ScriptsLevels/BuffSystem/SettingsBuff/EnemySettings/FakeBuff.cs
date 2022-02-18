using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace ScriptsLevels.BuffSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuffSettings/EnemyBuff/Fake", order = 20)]
    public class FakeBuff : SettingsBuff<Enemy>
    {
        public override IPassiveBuff GetBuff(Enemy buffObject)
        {
            return null;
        }
    }
}