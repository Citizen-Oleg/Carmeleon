using System.Collections.Generic;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RadiusTargetsProvider : MonoBehaviour, ITargetsProvider
    {
        [SerializeField]
        private LayerMask _enemyLayer;
        
        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        private readonly List<Enemy> _targets = new List<Enemy>();
        
        public List<Enemy> GetTargets(float radius)
        {
            if (_targets.Count != 0)
            {
                _targets.Clear();
            }
            
            var count = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _colliders2D, _enemyLayer);

            if (count == 0)
            {
                return _targets;
            }
            
            for (var i = 0; i < count; i++)
            {
                if (_colliders2D[i] == null)
                {
                    break;
                }
                if (_colliders2D[i].TryGetComponent(out Enemy enemy))
                {
                    _targets.Add(enemy);
                }
            }

            return _targets;
        }
        
    }
}