using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/StoreDiscount", order = 2)]
    public class StoreDiscountTalent : Talent
    {
        [SerializeField]
        private float _amountDiscount;
        
        public override void ActivateTalent()
        {
            GameManager.PlayerData.StoreDiscount += _amountDiscount;
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.StoreDiscount -= _amountDiscount;
        }
    }
}