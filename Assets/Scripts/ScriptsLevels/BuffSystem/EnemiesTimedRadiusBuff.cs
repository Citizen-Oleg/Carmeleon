using System;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using JetBrains.Annotations;
using UnityEngine;

namespace ScriptsLevels.BuffSystem
{
    [RequireComponent(typeof(Enemy))]
    public class EnemiesTimedRadiusBuff : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _enemyLayer;
        [SerializeField]
        private SettingsBuff<Enemy> _settingsBuff;
        [SerializeField]
        private float _cooldownBuff;
        [SerializeField]
        private float _radiusBuff;

        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        
        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        private float _startTime;

        private Enemy _enemy;

        private void Start()
        {
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
            Physics2D.OverlapCircleNonAlloc(transform.position, _radiusBuff, _colliders2D, _enemyLayer);
            foreach (var collider in _colliders2D)
            {
                if (collider == null)
                {
                    break;
                }
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.EnemyBuffController.AddBuff(_settingsBuff);
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