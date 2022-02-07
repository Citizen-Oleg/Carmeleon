using System.Collections.Generic;
using EnemyComponent;

namespace Interface
{
    public interface ITargetsProvider<T>
    {
        public List<T> GetTargets(float radius);
    }
}