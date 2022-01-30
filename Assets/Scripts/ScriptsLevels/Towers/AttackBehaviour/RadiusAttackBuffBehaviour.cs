using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RadiusAttackBuffBehaviour : RadiusAttackBehaviour, IBuffBehaviour<Enemy>
    {
        [Range(0, 100)]
        [SerializeField]
        private int _buffChance;
        [SerializeField]
        private SettingsBuff<Enemy> _buffEnemy;

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
            target.EnemyBuffController.AddBuff(_buffEnemy);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_buffEnemy);
        }
        
        private bool IsBuffAttack()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _buffChance;
        }
    }
}