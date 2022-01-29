using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Tower))]
    [RequireComponent(typeof(ITargetProvider))]
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private bool _hasTarget => _currentTarget != null;

        private Tower _tower;
        private IAttackBehaviour _attackBehaviour;
        private ITargetProvider _targetProvider;
        private Enemy _currentTarget;

        private void Awake()
        {
            _tower = GetComponent<Tower>();
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _targetProvider =  GetComponent<ITargetProvider>();
        }

        private void Update()
        {
            if (LevelManager.instance.StateLevel == StateLevel.Pause)
            {
                return;
            }
            
            RotationTower();
            
            var canShoot =  !_attackBehaviour.IsCooldown
                            && _tower.TowerCharacteristics.CanAttack
                            && !_tower.TowerAnimationController.IsActiveAnimationAttack();

            if (canShoot)
            {
                if (!_hasTarget && SetTarget() && _attackBehaviour.CanAttack(_currentTarget))
                {
                    _tower.TowerAnimationController.Attack();
                    return;
                }
                
                if (_hasTarget && !_attackBehaviour.CanAttack(_currentTarget))
                {
                    ResetTarget(_currentTarget);
                }

                if (_hasTarget && _attackBehaviour.CanAttack(_currentTarget))
                {
                    _tower.TowerAnimationController.Attack();
                }
            }
        }

        private void RotationTower()
        {
            if (_hasTarget)
            {
                var turn = _currentTarget.transform.position.x < transform.position.x ? 180 : 0;
                transform.eulerAngles = Vector3.up * turn;
            }
        }

        [UsedImplicitly]
        private void AttackEvent()
        {
            _tower.TowerAnimationController.ResetAttack();
            
            if (_hasTarget)
            {
                _attackBehaviour.Attack(_currentTarget);
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