using System.Collections.Generic;
using ResourceManager;
using UnityEngine;

namespace ScriptsMenu.Tree
{
    public class TreeTalent : MonoBehaviour
    {
        [SerializeField]
        private List<TalentNode> _startTalentNodes = new List<TalentNode>();
        [SerializeField]
        private List<TalentNode> _talentNodes = new List<TalentNode>();

        private ResourceManagerGame _resourceManagerGame;
        
        private void Awake()
        {
            _talentNodes = new BubbleSortTalentNode().Sort(_talentNodes);
            _resourceManagerGame = GameManager.ResourceManagerGame;
            
            OpenStartTalentNodes();
            SetActivatedTalents(GameManager.PlayerData.ActivatedTalentNodes);
        }

        public void ActivatedTalent(TalentNode talentNode)
        {
            talentNode.TalentData.IsActive = true;
            talentNode.TalentData.Talent.ActivateTalent();
            talentNode.Refresh();
            talentNode.OpenNextTalent();
        }

        public void DeactivateTalent(List<TalentNode> talentNodes)
        {
            foreach (var talentNode in talentNodes)
            {
                DeactivateTalent(talentNode);
            }
            
            OpenStartTalentNodes();
        }
        
        public void ActivatedTalent(List<TalentNode> talentNodes)
        {
            foreach (var talentNode in talentNodes)
            {
                ActivatedTalent(talentNode);
            }
        }
        
        private void DeactivateTalent(TalentNode talentNode)
        {
            _resourceManagerGame.AddResource(talentNode.Price);
            
            talentNode.TalentData.IsActive = false;
            talentNode.TalentData.Talent.DeactivateTalent();
            talentNode.CloseTalent();
            talentNode.CloseNextTalent();
            talentNode.Refresh();
        }

        private void OpenStartTalentNodes()
        {
            foreach (var talentNode in _startTalentNodes)
            {
                talentNode.OpenTalent();
            }
        }

        private void SetActivatedTalents(List<TalentNode> activatedNodes)
        {
            foreach (var activatedNode in activatedNodes)
            {
                var talentData = activatedNode.TalentData;
                if (talentData.ID == _talentNodes[talentData.ID].TalentData.ID)
                {
                    var talent = _talentNodes[talentData.ID];
                    talent.OpenTalent();
                    ActivatedTalent(talent);
                }
                else
                {
                    SetActivatedTalent(activatedNode);
                }
            }
        }

        private void SetActivatedTalent(TalentNode talentNode)
        {
            for (int i = talentNode.TalentData.ID; i < _talentNodes.Count; i++)
            {
                if (talentNode.TalentData.ID == _talentNodes[i].TalentData.ID)
                {
                    var talent = _talentNodes[i];
                    ActivatedTalent(talent);
                    talent.OpenTalent();
                }
            }
        }
    }
    
    class BubbleSortTalentNode
    {
        public List<TalentNode> Sort(List<TalentNode> talentNodes)
        {
            for (int i = 0; i < talentNodes.Count; i++)
            {
                for (int j = i + 1; j < talentNodes.Count; j++)
                {
                    if (talentNodes[i].TalentData.ID > talentNodes[j].TalentData.ID)
                    {
                        (talentNodes[i], talentNodes[j]) = (talentNodes[j], talentNodes[i]);
                    }
                }
            }

            return talentNodes;
        }
    }
}
