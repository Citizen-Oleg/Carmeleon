using Inventory;
using Loot;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/ReagentItem", order = 2)]
    public class ReagentItem : Item
    {
        public override string Name => _reagent.Name;

        [SerializeField]
        private Reagent _reagent;
    }
}