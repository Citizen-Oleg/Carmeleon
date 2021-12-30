using System.Collections.Generic;
using BuffSystem;
using BuffSystem.SettingsBuff;
using EnemyComponent;
using UnityEngine;

namespace Towers
{
    public class NearestBuffTargetProvider
    {
        public Enemy GetNearestNoBuffTarget(List<Enemy> targets, Vector2 position, SettingsBuff<Enemy> settingsBuff,
            float radius = float.MaxValue)
        {
            return GetNearestTarget(false, targets, position, settingsBuff, radius);
        }

        public Enemy GetNearestBuffTarget(List<Enemy> targets, Vector2 position, SettingsBuff<Enemy> settingsBuff,
            float radius = float.MaxValue)
        {
            return GetNearestTarget(true, targets, position, settingsBuff, radius);
        }

        private Enemy GetNearestTarget(bool hasBuff, List<Enemy> targets, Vector2 position, SettingsBuff<Enemy> settingsBuff,
            float radius = float.MaxValue)
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

                var buffController = target.EnemyBuffController;
                if (minDistance > distanceToTarget && buffController.HasBuff(settingsBuff) == hasBuff 
                                                   && buffController.IsActiveBuff(settingsBuff) == hasBuff) 
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