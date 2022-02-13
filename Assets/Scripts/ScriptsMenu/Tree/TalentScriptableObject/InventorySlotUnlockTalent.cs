using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/InventorySlotUnlock", order = 4)]
    public class InventorySlotUnlockTalent : Talent
    {
        [SerializeField]
        private int _count;
        
        public override void ActivateTalent()
        {
            GameManager.PlayerData.InventorySize += _count;
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.InventorySize -= _count;
        }
    }
}