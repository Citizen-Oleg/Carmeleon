using EnemyComponent;
using Interface;
using JetBrains.Annotations;
using Towers;
using UnityEngine;

namespace ScriptsLevels.BuffSystem.BuffingBehavior
{
    [RequireComponent(typeof(IBuffBehaviour<Tower>))]
    [RequireComponent(typeof(IBuffBehaviour<Tower>))]
    [RequireComponent(typeof(Enemy))]
    public class TowersTimedRadiusBuff : MonoBehaviour
    {
        [SerializeField]
        private float _cooldownBuff;
        [SerializeField]
        private float _radiusBuff;

        private bool IsCooldown => _startTime + _cooldownBuff > Time.time;
        private float _startTime;

        private IBuffBehaviour<Tower> _buffBehaviour;
        private ITargetsProvider<Tower> _targetsProvider;
        private Enemy _enemy;

        private void Start()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Tower>>();
            _targetsProvider = GetComponent<ITargetsProvider<Tower>>();
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
            
            foreach (var tower in targets)
            {
                _buffBehaviour.BuffTarget(tower);
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