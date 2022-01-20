using Inventory;
using ScriptsLevels.Inventory;
using UnityEngine;

namespace ScriptsMenu.Tree.TalentScriptableObject
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Talent/TowerUnlock", order = 0)]
    public class TowerUnlockTalent : Talent
    {
        [SerializeField]
        private TowerItem _towerItem;

        public override void ActivateTalent()
        {
            GameManager.PlayerData.AddImprovedTower(_towerItem);
        }

        public override void DeactivateTalent()
        {
            GameManager.PlayerData.RemoveImprovedTower(_towerItem);
        }
    }
}