using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RadiusAttackBuffBehaviour : RadiusAttackBehaviour, IBuffBehaviour<Enemy>
    {
        public SettingsBuff<Enemy> SettingsBuff => _buffEnemy;
        
        [SerializeField]
        private SettingsBuff<Enemy> _buffEnemy;

        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);
            BuffTarget(enemy);
        }

        public void BuffTarget(Enemy target)
        {
            target.EnemyBuffController.AddBuff(_buffEnemy);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_buffEnemy);
        }
    }
}