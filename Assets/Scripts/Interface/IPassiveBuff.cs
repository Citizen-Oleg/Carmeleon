using System;

namespace Interface
{
    public interface IPassiveBuff
    {
        bool IsActive { get; }
        
        void Start();
        void Stop();
    }
}