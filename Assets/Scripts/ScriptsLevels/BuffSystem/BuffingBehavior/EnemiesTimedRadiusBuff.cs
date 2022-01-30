using System;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using UnityEngine;

namespace ScriptsLevels.BuffSystem
{
    [RequireComponent(typeof(IBuffBehaviour<Enemy>))]
    [RequireComponent(typeof(Enemy))]
    public class EnemiesTimedRadiusBuff : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _enemyLayer;
        [SerializeField]
        private float _cooldownBuff;
        [SerializeField]
        private float _radiusBuff;

        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        
        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        private float _startTime;

        private IBuffBehaviour<Enemy> _buffBehaviour;
        private Enemy _enemy;

        private void Start()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Enemy>>();
            _enemy = GetComponent<Enemy>();
            _startTime = Time.time;
        }

        private void Update()
        {
            if (!IsCooldown && _enemy.CharacteristicsEnemy.IsMoving)
            {
                _enemy.CharacteristicsEnemy.IsCast = true;
                _enemy.EnemyAnimationController.CastBuff();
            }
        }

        [UsedImplicitly]
        private void ApplyBuff()
        {
            var count = Physics2D.OverlapCircleNonAlloc(transform.position, _radiusBuff, _colliders2D, _enemyLayer);
            for (var i = 0; i < count; i++)
            {
                if (_colliders2D[i] == null)
                {
                    break;
                }
                
                if (_colliders2D[i].TryGetComponent(out Enemy enemy))
                {
                    _buffBehaviour.BuffTarget(enemy);
                }
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