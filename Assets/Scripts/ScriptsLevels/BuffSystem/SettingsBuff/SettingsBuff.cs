using Interface;
using UnityEngine;

namespace BuffSystem.SettingsBuff
{
    public abstract class SettingsBuff<T> : ScriptableObject
    {
        public string Name => _name;
        public string Description => _description;
        public Sprite Sprite => _sprite;

        [SerializeField]
        private string _name;
        [SerializeField]
        private string _description;
        [SerializeField]
        private Sprite _sprite;
        
        public abstract IPassiveBuff GetBuff(T buffObject);
    }
}