using System.Collections.Generic;
using EnemyComponent;
using UnityEngine;

namespace Towers
{
    public class NearestTargetProvider
    {
        public Enemy GetNearestTarget(List<Enemy> targets, Vector2 position, float radius = float.MaxValue)
        {
            if (targets.Count == 0)
            {
                return null;
            }
            
            var minDistance = float.MaxValue;
            var minIndex = 0;

            for (var index = 0; index < targets.Count; index++)
            {
                var target = targets[index];
                var distanceToTarget = Vector2.Distance(target.transform.position, position);
                
                if (minDistance > distanceToTarget)
                {
                    minDistance = distanceToTarget;
                    minIndex = index;
                }
            }
            
            var distanceToNearestTarget = Vector2.Distance(targets[minIndex].transform.position, position);

            return distanceToNearestTarget <= radius ? targets[minIndex] : null;
        }
    }
}
