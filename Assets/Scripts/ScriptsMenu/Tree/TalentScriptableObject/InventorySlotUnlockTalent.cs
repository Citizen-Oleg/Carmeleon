using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/InventorySlotUnlock", order = 4)]
    public class InventorySlotUnlockTalent : Talent
    {
        public override void ActivateTalent()
        {
            GameManager.PlayerData.InventorySize++;
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.InventorySize--;
        }
    }
}