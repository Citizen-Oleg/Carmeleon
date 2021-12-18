using System;
using EnemyComponent;

namespace Towers
{
    public interface IAttackBehaviour
    {
        bool IsCooldown { get; }
        bool CanAttack(Enemy enemy);
        void Attack(Enemy enemy);
    }
}