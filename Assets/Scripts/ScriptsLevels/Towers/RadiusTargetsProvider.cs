using System.Collections.Generic;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RadiusTargetsProvider : MonoBehaviour, ITargetsProvider
    {
        private Collider2D[] _colliders2D = new Collider2D[20];
        private List<Enemy> _targets = new List<Enemy>();
        
        public List<Enemy> GetTargets(float radius)
        {
            if (_targets.Count != 0)
            {
                _targets.Clear();
            }
            
            Physics2D.OverlapCircleNonAlloc(transform.position, radius, _colliders2D);
            foreach (var collider in _colliders2D)
            {
                if (collider == null)
                {
                    break;
                }
                if (collider.TryGetComponent(out Enemy enemy))
                {
                    _targets.Add(enemy);
                }
            }

            return _targets;
        }
        
    }
}