using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace AttackBehavior
{
    public class GlobalAttackBuffBehaviour : GlobalAttackBehaviour, IBuffBehaviour<Enemy>
    {
        public SettingsBuff<Enemy> SettingsBuff => _enemyBuff;
        
        [SerializeField]
        private float _chanceApplyBuff;
        [SerializeField]
        private SettingsBuff<Enemy> _enemyBuff;
        
        public override void Attack(Enemy enemy)
        {
            base.Attack(enemy);

            if (HasBuffChance())
            {
                BuffTarget(enemy);
            }
        }
        
        private bool HasBuffChance()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _chanceApplyBuff;
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