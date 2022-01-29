using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RangeAttackBuffBehavior : RangeAttackBehavior, IBuffBehaviour<Enemy>
    {
        public SettingsBuff<Enemy> SettingsBuff => _buffEnemy;
        
        [SerializeField]
        private SettingsBuff<Enemy> _buffEnemy;

        public override void Attack(Enemy enemy)
        {
            Debug.Log("Атака у поведения");
            _lastShotTime = Time.time;
            var product = _projectileFactory.GetProduct(_prefabProjectile);
            
            if (product is Projectile projectile)
            {
                projectile.transform.position = _projectileLaunchPosition.position;
                projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType,
                    _buffEnemy);
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
    }
}