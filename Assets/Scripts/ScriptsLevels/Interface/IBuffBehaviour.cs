using BuffSystem;
using BuffSystem.SettingsBuff;

namespace Interface
{
    public interface IBuffBehaviour<T>
    {
        void BuffTarget(T target);
        void StopBuffTarget(T target);
    }
}