using System;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Bestiary.View
{
    [Serializable]
    public class TextDamageType
    {
        public DamageType DamageType => _damageType;
        public string NameType => _nameType;

        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private string _nameType;
    }
}