using ScriptsLevels.Inventory;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BestiaryItem/Reagent", order = 1)]
    public class BestiaryItemReagent : BestiaryItem<ReagentItem>
    {
    }
}