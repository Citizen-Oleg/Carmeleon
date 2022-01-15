using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    public abstract class Talent : ScriptableObject
    {
        public Sprite IconTalent => _iconTalent;
        public string Description => _description;

        [SerializeField]
        private Sprite _iconTalent;
        [SerializeField]
        private string _description;
        
        public abstract void ActivateTalent();
        public abstract void DeactivateTalent();
    }
}