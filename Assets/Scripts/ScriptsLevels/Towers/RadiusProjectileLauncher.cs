using System;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(ITargetsProvider))]
    [RequireComponent(typeof(IAttackBehaviour))]
    [RequireComponent(typeof(TowerCharacteristics))]
    public class RadiusProjectileLauncher : MonoBehaviour
    {
        private ITargetsProvider _targetsProvider;
        private IAttackBehaviour _attackBehaviour;
        private TowerCharacteristics _towerCharacteristics;

        private void Awake()
        {
            _targetsProvider = GetComponent<ITargetsProvider>();
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _towerCharacteristics = GetComponent<TowerCharacteristics>();
        }

        private void Update()
        {
            if (!_attackBehaviour.IsCooldown)
            {
                foreach (var enemy in _targetsProvider.GetTargets(_towerCharacteristics.AttackRadius))
                {
                    if (_attackBehaviour.CanAttack(enemy))
                    {
                        _attackBehaviour.Attack(enemy);
                    }
                }
            }
        }
    }
}