using Level.ScriptsMenu.Interface;
using UnityEngine;

namespace ScriptsMenu.Modifiers
{
    public abstract class Modifier : ScriptableObject
    {
        public string Description => _description;

        [SerializeField]
        private string _description;
        
        public abstract IModifier GetModificator();
    }
}
