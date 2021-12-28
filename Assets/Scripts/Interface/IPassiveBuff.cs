using System;

namespace Interface
{
    public interface IPassiveBuff
    {
        event Action<IPassiveBuff> OnStopBuff;
        
        bool IsActive { get; }
        
        void Start();
        void Stop();
    }
}