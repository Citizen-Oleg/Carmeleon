using System;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace ScriptsLevels.BuffSystem
{
    [RequireComponent(typeof(ITargetsProvider<Enemy>))]
    [RequireComponent(typeof(IBuffBehaviour<Enemy>))]
    [RequireComponent(typeof(Enemy))]
    public class EnemiesTimedRadiusBuff : MonoBehaviour
    {
        [SerializeField]
        private float _cooldownBuff;
        [SerializeField]
        private float _radiusBuff;

        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        
        private float _startTime;

        private ITargetsProvider<Enemy> _targetsProvider;
        private IBuffBehaviour<Enemy> _buffBehaviour;
        private Enemy _enemy;

        private void Start()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Enemy>>();
            _targetsProvider = GetComponent<ITargetsProvider<Enemy>>();
            _enemy = GetComponent<Enemy>();
            _startTime = Time.time;
        }

        private void Update()
        {
            if (!IsCooldown && _enemy.CharacteristicsEnemy.IsMoving)
            {
                _enemy.CharacteristicsEnemy.IsCast = true;
                _enemy.EnemyAnimationController.Cast();
            }
        }

        [UsedImplicitly]
        private void ApplyBuff()
        {
            var targets = _targetsProvider.GetTargets(_radiusBuff);

            foreach (var enemy in targets)
            {
                _buffBehaviour.BuffTarget(enemy);
            }

            _enemy.EnemyAnimationController.ResetCast();
            _enemy.CharacteristicsEnemy.IsCast = false;
            _startTime = Time.time;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusBuff);
        }
#endif
    }
}