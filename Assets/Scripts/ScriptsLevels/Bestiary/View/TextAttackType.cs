using System;
using EnemyComponent;
using UnityEngine;

namespace ScriptsLevels.Bestiary.View
{
    [Serializable]
    public class TextAttackType
    {
        public AttackType TypeAttack => _typeAttack;
        public string NameType => _nameType;

        [SerializeField]
        private AttackType _typeAttack;
        [SerializeField]
        private string _nameType;
    }
}