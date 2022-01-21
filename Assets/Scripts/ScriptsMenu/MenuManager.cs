using ScriptsMenu.Tree;
using Tools;
using UnityEngine;

namespace ScriptsMenu
{
    public class MenuManager : Singleton<MenuManager>
    {
        public static TreeTalent TreeTalent => instance._treeTalent;
        
        [SerializeField]
        private TreeTalent _treeTalent;
    }
}