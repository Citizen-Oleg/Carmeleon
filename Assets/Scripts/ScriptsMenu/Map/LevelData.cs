using System;
using System.Collections.Generic;
using ScriptsMenu.Modifiers;
using UnityEngine;

namespace ScriptsMenu.Map
{
    [Serializable]
    public class LevelData
    {
        [Newtonsoft.Json.JsonIgnore]
        public string NameScene
        {
            get => _nameScene;
            set => _nameScene = value;
        }
        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }
        public bool IsPassedEasyLevel
        {
            get => _isPassedEasyLevel;
            set => _isPassedEasyLevel = value;
        }
        public bool IsPassedAverageLevel
        {
            get => _isPassedAverageLevel;
            set => _isPassedAverageLevel = value;
        }
        public bool IsPassedHighLevel
        {
            get => _isPassedHighLevel;
            set => _isPassedHighLevel = value;
        }

        public bool HasGoldBorder { get; set; }
        
        public List<ModifierData> Modifiers
        {
            get => _modifiers;
            set => _modifiers = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string NameLevel => _nameLevel;
        public string Description => _description;

        [SerializeField]
        private int _id;
        [SerializeField]
        private string _nameScene;
        [SerializeField]
        private bool _isOpen;
        [SerializeField]
        private bool _isPassedEasyLevel;
        [SerializeField]
        private bool _isPassedAverageLevel;
        [SerializeField]
        private bool _isPassedHighLevel;
        [Newtonsoft.Json.JsonIgnore]
        [SerializeField]
        private List<ModifierData> _modifiers = new List<ModifierData>();
        
        [Header("UI data")]
        [SerializeField]
        private string _nameLevel;
        [SerializeField]
        private string _description;
    }
}