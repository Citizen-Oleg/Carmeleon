using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RangeAttackBuffBehavior : RangeAttackBehavior, IBuffBehaviour<Enemy>
    {
        [Range(0, 100)]
        [SerializeField]
        private int _buffChance;
        [SerializeField]
        private SettingsBuff<Enemy> _buffEnemy;

        public override void Attack(Enemy enemy)
        {
            if (!IsBuffProjectile())
            {
                base.Attack(enemy);
                return;
            }
            
            _lastShotTime = Time.time;
            
            var projectile = GetProjectile();
            projectile.transform.position = _projectileLaunchPosition.position;
            projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType,
                    _buffEnemy);
        }

        private bool IsBuffProjectile()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _buffChance;
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