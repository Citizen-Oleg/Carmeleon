using System;
using UnityEngine;

namespace ScriptsMenu.Map
{
    [Serializable]
    public class LevelData
    {
        public int ID
        {
            get => _id;
            set => _id = value;
        }
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
    }
}