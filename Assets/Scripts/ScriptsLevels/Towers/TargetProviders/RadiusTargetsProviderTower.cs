using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Towers
{
    public class RadiusTargetsProviderTower : MonoBehaviour, ITargetsProvider<Tower>
    {
        [SerializeField]
        private LayerMask _towerLayer;
        
        private readonly Collider2D[] _colliders2D = new Collider2D[GlobalConstant.DEFAULT_SIZE_COLLIDERS_ARRAY];
        private readonly List<Tower> _targets = new List<Tower>();
        
        public List<Tower> GetTargets(float radius)
        {
            if (_targets.Count != 0)
            {
                _targets.Clear();
            }
            
            var count = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _colliders2D, _towerLayer);

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
                if (_colliders2D[i].TryGetComponent(out Tower tower))
                {
                    _targets.Add(tower);
                }
            }

            return _targets;
        }
    }
}