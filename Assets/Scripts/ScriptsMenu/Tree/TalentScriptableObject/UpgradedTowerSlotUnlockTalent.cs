using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/UpgradedTowerSlotUnlock", order = 1)]
    public class UpgradedTowerSlotUnlockTalent : Talent
    {
        public override void ActivateTalent()
        {
            GameManager.PlayerData.ImprovedTowersSize++;
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.ImprovedTowersSize--;
        }
    }
}