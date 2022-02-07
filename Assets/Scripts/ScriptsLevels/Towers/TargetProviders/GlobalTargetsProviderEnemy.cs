using System.Collections.Generic;
using EnemyComponent;
using Interface;
using Level;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    public class GlobalTargetsProviderEnemy : MonoBehaviour, ITargetsProvider<Enemy>
    {
        public List<Enemy> GetTargets(float radius)
        {
            return new List<Enemy>(LevelManager.EnemyManager.Enemies);
        }
    }
}