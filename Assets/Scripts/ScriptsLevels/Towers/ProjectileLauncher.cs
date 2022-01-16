using EnemyComponent;
using Interface;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(ITargetProvider))]
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private bool _hasTarget => _currentTarget != null;
        
        private IAttackBehaviour _attackBehaviour;
        private ITargetProvider _targetProvider;
        private Enemy _currentTarget;

        private void Awake()
        {
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _targetProvider =  GetComponent<ITargetProvider>();
        }

        private void Update()
        {
            if (!_attackBehaviour.IsCooldown && LevelManager.instance.StateLevel != StateLevel.Pause)
            {
                if (!_hasTarget && SetTarget() && _attackBehaviour.CanAttack(_currentTarget))
                {
                    _attackBehaviour.Attack(_currentTarget);
                    return;
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
        
        private void OnDisable()
        {
            _currentTarget = null;
        }

        private Enemy GetTarget()
        {
            return _targetProvider.GetTarget();
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