using BuffSystem;
using BuffSystem.SettingsBuff;

namespace Interface
{
    public interface IBuffBehaviour<T>
    {
        SettingsBuff<T> SettingsBuff { get; }
        void BuffTarget(T target);
        void StopBuffTarget(T target);
    }
}