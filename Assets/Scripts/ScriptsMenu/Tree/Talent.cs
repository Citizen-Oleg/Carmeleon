using UnityEngine;

namespace ScriptsMenu.Tree
{
    public abstract class Talent : ScriptableObject
    {
        public abstract void ActivateTalent();
        public abstract void DeactivateTalent();
    }
}