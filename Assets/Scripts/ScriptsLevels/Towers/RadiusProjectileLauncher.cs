using System;
using System.Collections.Generic;
using System.Linq;
using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(ITargetsProvider<Enemy>))]
    [RequireComponent(typeof(IAttackBehaviour))]
    [RequireComponent(typeof(Tower))]
    public class RadiusProjectileLauncher : MonoBehaviour
    {
        private ITargetsProvider<Enemy> _targetsProvider;
        private IAttackBehaviour _attackBehaviour;
        private Tower _tower;
        
        private void Awake()
        {
            _targetsProvider = GetComponent<ITargetsProvider<Enemy>>();
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _tower = GetComponent<Tower>();
        }

        private void Update()
        {
            var canShoot =  !_attackBehaviour.IsCooldown
                            && _tower.TowerCharacteristics.CanAttack
                            && !_tower.TowerAnimationController.IsActiveAnimationAttack();
            if (canShoot)
            {
                var targets = _targetsProvider.GetTargets(_tower.TowerCharacteristics.AttackRadius);

                if (targets.Count != 0 && targets.FirstOrDefault(target => _attackBehaviour.CanAttack(target)))
                {
                    _tower.TowerAnimationController.Attack();
                }
            }
        }

        [UsedImplicitly]
        private void AttackEvent()
        {
            _tower.TowerAnimationController.ResetAttack();
            var targets = _targetsProvider.GetTargets(_tower.TowerCharacteristics.AttackRadius);
            foreach (var enemy in targets)
            {
                if (_attackBehaviour.CanAttack(enemy))
                {
                    _attackBehaviour.Attack(enemy);
                }
            }
        }
    }
}