using Level.ScriptsMenu.Interface;
using UnityEngine;

namespace ScriptsMenu.Modifiers
{
    public abstract class Modifier : ScriptableObject
    {
        public abstract IModifier GetModificator();
    }
}
