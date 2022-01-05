using System.Collections;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace AttackBehavior
{
    public class QueueBuffAttackBehavior : RangeAttackBehavior
    {
        [SerializeField]
        private int _numberShells;
        [SerializeField]
        private float _delayShot;
        [SerializeField]
        private float _chanceApplyBuff;
        [SerializeField]
        private SettingsBuff<Enemy> _enemyBuff;
        [SerializeField]
        private Projectile _lastShotBuff;

        public override void Attack(Enemy enemy)
        {
            StartCoroutine(QueueAttack(enemy));
            _lastShotTime = Time.time;
        }

        private IEnumerator QueueAttack(Enemy enemy)
        {
            for (int i = 0; i < _numberShells && CanAttack(enemy); i++)
            {
                if (i == _numberShells && HasBuffChance())
                {
                    var projectile = GetProjectile(_projectileFactory.GetProduct(_lastShotBuff));
                    projectile.transform.position = transform.position;
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType,
                            _enemyBuff);
                }
                else
                {
                    var projectile = GetProjectile(_projectileFactory.GetProduct(_prefabProjectile));
                    projectile.transform.position = transform.position;
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType,
                            _enemyBuff);
                    
                }

                yield return new WaitForSeconds(_delayShot);
            }
        }
        
        private bool HasBuffChance()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _chanceApplyBuff;
        }

        private Projectile GetProjectile(IProduct product)
        {
            return product as Projectile;
        }
    }
}