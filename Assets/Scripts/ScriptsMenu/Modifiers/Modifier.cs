using Level.ScriptsMenu.Interface;
using UnityEngine;

namespace ScriptsMenu.Modifiers
{
    public abstract class Modifier : ScriptableObject
    {
        public bool IsPassed { get; set; }
        public bool IsActive { get; set; }
        public abstract IModifier GetModificator();
    }
}
