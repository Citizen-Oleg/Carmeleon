using System.Collections.Generic;
using EnemyComponent;
using Interface;
using Level;
using UnityEngine;

namespace Towers
{
    public class GlobalTargetsProvider : MonoBehaviour, ITargetsProvider
    {
        public List<Enemy> GetTargets(float radius)
        {
            return new List<Enemy>(LevelManager.EnemyManager.Enemies);
        }
    }
}