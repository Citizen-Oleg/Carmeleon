using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/ReagentSlotUnlock", order = 3)]
    public class ReagentSlotUnlockTalent : Talent
    {
        public override void ActivateTalent()
        {
            GameManager.PlayerData.ReagentShopSize++;
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.ReagentShopSize--;
        }
    }
}