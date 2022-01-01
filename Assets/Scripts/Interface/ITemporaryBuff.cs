using System;

namespace Interface
{
    public interface ITemporaryBuff : IPassiveBuff
    {
        void Update();
        void Refresh();
    }
}