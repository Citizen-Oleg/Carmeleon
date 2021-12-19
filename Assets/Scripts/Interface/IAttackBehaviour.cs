using EnemyComponent;

namespace Interface
{
    public interface IAttackBehaviour
    {
        bool IsCooldown { get; }
        bool CanAttack(Enemy enemy);
        void Attack(Enemy enemy);
    }
}