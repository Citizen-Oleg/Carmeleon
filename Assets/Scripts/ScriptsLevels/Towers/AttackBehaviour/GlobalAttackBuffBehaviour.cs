using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class GlobalAttackBuffBehaviour : GlobalAttackBehaviour, IBuffBehaviour<Enemy>
    {
        [Range(0, 100)]
        [SerializeField]
        private int _buffChance;
        [SerializeField]
        private SettingsBuff<Enemy> _enemyBuff;
        
        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);
            
            if (IsBuffAttack())
            {
                BuffTarget(enemy);
            }
        }

        public void BuffTarget(Enemy target)
        {
            target.EnemyBuffController.AddBuff(_enemyBuff);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_enemyBuff);
        }
        
        private bool IsBuffAttack()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _buffChance;
        }
    }
}