using System;
using ScriptsMenu.Tree.TalentScriptableObject;
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
        
        [Newtonsoft.Json.JsonIgnore]
        public Talent Talent
        {
            get => _talent;
            set => _talent = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        [SerializeField]
        private int _id;
        [SerializeField]
        private bool _isOpen;
        [SerializeField]
        private bool _isActive;
        [Newtonsoft.Json.JsonIgnore]
        [SerializeField]
        private Talent _talent;
    }
}