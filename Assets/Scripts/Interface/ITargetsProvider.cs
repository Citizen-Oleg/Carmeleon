using System.Collections.Generic;
using EnemyComponent;

namespace Interface
{
    public interface ITargetsProvider
    {
        public List<Enemy> GetTargets(float radius);
    }
}