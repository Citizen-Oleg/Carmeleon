using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    public abstract class SettingsBuff<T> : ScriptableObject 
    {
        public abstract IPassiveBuff GetBuff(T buffObject);
    }
}