using System;
using EnemyComponent;
using Interface;
using Towers;
using UnityEngine;

namespace ScriptsLevels.BuffSystem.BuffingBehavior
{
    [RequireComponent(typeof(Enemy))]
    public class TimedTargetTowerBuff : MonoBehaviour
    {
        [SerializeField]
        private float _cooldownBuff;
        
        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        private float _startTime;
        
        private IBuffBehaviour<Tower> _buffBehaviour;
        private ITargetProvider<Tower> _targetProvider;
        private Enemy _enemy;

        private void Awake()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Tower>>();
            _targetProvider = GetComponent<ITargetProvider<Tower>>();
            _enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            if (!IsCooldown && _enemy.CharacteristicsEnemy.IsMoving)
            {
                var target = _targetProvider.GetTarget();

                if (target != null)
                {
                    _buffBehaviour.BuffTarget(target);
                }
            }
        }
    }
}