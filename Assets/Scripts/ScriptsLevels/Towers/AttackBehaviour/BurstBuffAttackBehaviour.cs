using System.Collections;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class BurstBuffAttackBehaviour : BurstAttackBehaviour, IBuffBehaviour<Enemy>
    {
        [Range(0, 100)]
        [SerializeField]
        private int _buffChance;
        [SerializeField]
        private SettingsBuff<Enemy> _settingsBuffEnemy;

        protected override IEnumerator BurstAttack(Enemy enemy)
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

                if (IsBuffAttack())
                {
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType, _settingsBuffEnemy);
                }
                else
                {
                    projectile.Initialize(_towerCharacteristics.Damage, enemy, Callback, _towerCharacteristics.DamageType);
                }

                yield return new WaitForSeconds(_delayBeforeFiring);
            }

            _lastShotTime = Time.time;
            yield return null;
        }
        
        private bool IsBuffAttack()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _buffChance;
        }

        public void BuffTarget(Enemy target)
        {
            target.EnemyBuffController.AddBuff(_settingsBuffEnemy);
        }

        public void StopBuffTarget(Enemy target)
        {
            target.EnemyBuffController.StopBuff(_settingsBuffEnemy);
        }
    }
}