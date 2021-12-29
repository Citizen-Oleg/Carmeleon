using BuffSystem;

namespace Interface
{
    public interface IBuffBehaviour<T>
    {
        bool CanBuff(T target);
        void BuffTarget(T target);
        void StopBuffTarget(T target);
    }
}