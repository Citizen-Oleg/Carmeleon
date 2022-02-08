using EnemyComponent;

namespace Interface
{
    public interface ITargetProvider<T>
    {
        T GetTarget();
    }
}