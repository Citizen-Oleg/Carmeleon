using EnemyComponent;

namespace Towers
{
    public class MeleeAttackBehaviour : IAttackBehaviour
    {
        public bool IsCooldown { get; }
        public bool CanAttack(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }

        public void Attack(Enemy enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}