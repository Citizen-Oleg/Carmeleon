using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ScriptsMenu.Modifiers
{
    [Serializable]
    public class ModifierData
    {
        public bool IsPassed { get; set; }
        public bool IsActive { get; set; }
        
        [JsonIgnore]
        public Modifier Modifier => _modifier;

        [SerializeField]
        private Modifier _modifier;
    }
}