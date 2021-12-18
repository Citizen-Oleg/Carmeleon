using System;
using EnemyComponent;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private IAttackBehaviour _attackBehaviour;
        private NearestTargetProvider _nearestTargetProvider;
        private Enemy _currentTarget;

        private bool _hasTarget => _currentTarget != null;

        private void Awake()
        {
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _nearestTargetProvider = new NearestTargetProvider();
        }

        private void Update()
        {
            if (!_attackBehaviour.IsCooldown)
            {
                if (!_hasTarget && SetTarget() && _attackBehaviour.CanAttack(_currentTarget))
                {
                    _attackBehaviour.Attack(_currentTarget);
                }
                
                if (_hasTarget && !_attackBehaviour.CanAttack(_currentTarget))
                {
                    ResetTarget(_currentTarget);
                }

                if (_hasTarget && _attackBehaviour.CanAttack(_currentTarget))
                {
                    _attackBehaviour.Attack(_currentTarget);
                }
            }
        }

        private Enemy GetTarget()
        {
            return _nearestTargetProvider.GetNearestTarget(LevelManager.EnemyManager.Enemies, transform.position);
        }

        private bool SetTarget()
        {
            _currentTarget = GetTarget();
            if (_currentTarget != null)
            {
                _currentTarget.HealthBehavior.OnDead += ResetTarget;
                return true;
            }

            return false;
        }
        
        private void ResetTarget(Enemy enemy)
        {
            enemy.HealthBehavior.OnDead -= ResetTarget;
            SetTarget();
        }

        private void OnDestroy()
        {
            if (_hasTarget)
            {
                _currentTarget.HealthBehavior.OnDead -= ResetTarget;
            }
        }
    }
}