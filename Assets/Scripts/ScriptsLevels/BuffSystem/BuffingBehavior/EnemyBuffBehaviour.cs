using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace ScriptsLevels.BuffSystem.BuffingBehavior
{
    public class EnemyBuffBehaviour : MonoBehaviour, IBuffBehaviour<Enemy>
    {
        [SerializeField]
        private SettingsBuff<Enemy> _settingsBuff;

        public void BuffTarget(Enemy target)
        {
            target.EnemyBuffController.AddBuff(_settingsBuff);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_settingsBuff);
        }
    }
}