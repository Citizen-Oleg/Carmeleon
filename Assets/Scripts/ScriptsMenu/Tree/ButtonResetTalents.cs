using JetBrains.Annotations;
using UnityEngine;

namespace ScriptsMenu.Tree
{
    public class ButtonResetTalents : MonoBehaviour
    {
        [SerializeField]
        private TreeTalent _treeTalent;

        [UsedImplicitly]
        public void ResetTalent()
        {
            var playerData = GameManager.PlayerData;
            var talents = playerData.ActivatedTalentNodes;
            
            _treeTalent.DeactivateTalent(talents);
            playerData.ClearActivatedNode();
        }
    }
}