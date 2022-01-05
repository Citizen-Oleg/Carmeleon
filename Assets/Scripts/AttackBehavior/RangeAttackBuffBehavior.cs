using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace AttackBehavior
{
    public class RangeAttackBuffBehavior : RangeAttackBehavior
    {
        public SettingsBuff<Enemy> SettingsBuff => _buffEnemy;

        [SerializeField]
        private float _chanceApplyBuff;
        [SerializeField]
        private SettingsBuff<Enemy> _buffEnemy;

        public override void Attack(Enemy enemy)
        {
            _lastShotTime = Time.time;
            var product = _projectileFactory.GetProduct(_prefabProjectile);
            
            if (product is Projectile projectile)
            {
                projectile.transform.position = transform.position;

                if (HasBuffChance())
                {
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback,
                        _towerCharacteristics.DamageType, _buffEnemy);
                }
                else
                {
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);
                }
            }
        }
        
        private bool HasBuffChance()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _chanceApplyBuff;
        }
    }
}