using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using Towers;
using UnityEngine;

namespace ScriptsLevels.BuffSystem.BuffingBehavior
{
    [RequireComponent(typeof(IBuffBehaviour<Tower>))]
    [RequireComponent(typeof(Enemy))]
    public class TowersTimedRadiusBuff : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _layer;
        [SerializeField]
        private float _cooldownBuff;
        [SerializeField]
        private float _radiusBuff;

        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        
        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        private float _startTime;

        private IBuffBehaviour<Tower> _buffBehaviour;
        private Enemy _enemy;

        private void Start()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Tower>>();
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
            var count = Physics2D.OverlapCircleNonAlloc(transform.position, _radiusBuff, _colliders2D, _layer);
            for (var i = 0; i < count; i++)
            {
                if (_colliders2D[i] == null)
                {
                    break;
                }
                
                if (_colliders2D[i].TryGetComponent(out Tower tower))
                {
                    _buffBehaviour.BuffTarget(tower);
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