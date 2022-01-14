using System;
using UnityEngine;

namespace ScriptsMenu.Tree
{
    [Serializable]
    public class TalentData
    {
        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public Talent Talent
        {
            get => _talent;
            set => _talent = value;
        }

        public int ID => _id;

        [SerializeField]
        private int _id;
        [SerializeField]
        private bool _isOpen;
        [SerializeField]
        private bool _isActive;
        [SerializeField]
        private Talent _talent;
    }
}