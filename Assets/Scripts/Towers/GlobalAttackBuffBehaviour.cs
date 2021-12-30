using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class GlobalAttackBuffBehaviour : GlobalAttackBehaviour, IBuffBehaviour<Enemy>
    {
        public SettingsBuff<Enemy> SettingsBuff => _enemyBuff;
        
        [SerializeField]
        private SettingsBuff<Enemy> _enemyBuff;
        
        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);
            BuffTarget(enemy);
        }

        public void BuffTarget(Enemy target)
        {
            target.EnemyBuffController.AddBuff(_enemyBuff);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_enemyBuff);
        }
    }
}