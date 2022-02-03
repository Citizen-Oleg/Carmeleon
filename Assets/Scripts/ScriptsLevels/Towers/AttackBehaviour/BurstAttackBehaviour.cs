using System;
using System.Collections;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class BurstAttackBehaviour : RangeAttackBehavior
    {
        [SerializeField]
        protected int _numberShots;
        [SerializeField]
        protected float _delayBeforeFiring;
        
        public override void Attack(Enemy enemy)
        {
            StartCoroutine(BurstAttack(enemy));
        }

        protected virtual IEnumerator BurstAttack(Enemy enemy)
        {
            for (int i = 0; i < _numberShots; i++)
            {
                if (!CanAttack(enemy))
                {
                    _tower.TowerAnimationController.Refresh();
                    _lastShotTime = Time.time;
                    yield break;
                }
                
                var projectile = GetProjectile();
                projectile.transform.position = _projectileLaunchPosition.position;
                projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);

                yield return new WaitForSeconds(_delayBeforeFiring);
            }

            _lastShotTime = Time.time;
            yield return null;
        }
    }
}