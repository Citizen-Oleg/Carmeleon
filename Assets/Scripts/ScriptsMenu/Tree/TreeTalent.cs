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
        
        private void Start()
        {
            _talentNodes = new BubbleSortTalentNode().Sort(_talentNodes);
            _resourceManagerGame = GameManager.ResourceManagerGame;
            
            OpenStartTalentNodes();
            SetOpenTalents(GameManager.PlayerData.ActivatedTalentDatas);
        }

        public void ActivatedTalent(TalentNode talentNode)
        {
            OpenActivatedTalent(talentNode);
            talentNode.TalentData.Talent.ActivateTalent();
        }

        public void OpenActivatedTalent(TalentNode talentNode)
        {
            talentNode.TalentData.IsActive = true;
            talentNode.OpenTalent();
            talentNode.OpenNextTalent();
            talentNode.Refresh();
        }

        public void DeactivateTalent(List<TalentData> talentDatas)
        {
            foreach (var talentData in talentDatas)
            {
                if (talentData.ID == _talentNodes[talentData.ID].TalentData.ID)
                {
                    var talent = _talentNodes[talentData.ID];
                    DeactivateTalent(talent);
                }
                else
                {
                    DeactivateTalent(talentData);
                }
            }
            
            OpenStartTalentNodes();
        }
        
        private void DeactivateTalent(TalentData talentData)
        {
            for (int i = talentData.ID; i < _talentNodes.Count; i++)
            {
                if (talentData.ID == _talentNodes[i].TalentData.ID)
                {
                    var talent = _talentNodes[i];
                    DeactivateTalent(talent);
                }
            }
        }
        
        public void ActivatedTalent(List<TalentData> talentDatas)
        {
            foreach (var talantData in talentDatas)
            {
                if (talantData.ID == _talentNodes[talantData.ID].TalentData.ID)
                {
                    var talent = _talentNodes[talantData.ID];
                    ActivatedTalent(talent);
                }
                else
                {
                    SetActivateTalent(talantData);
                }
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
                talentNode.Refresh();
            }
        }

        private void SetOpenTalents(List<TalentData> talentDatas)
        {
            foreach (var talantData in talentDatas)
            {
                if (talantData.ID == _talentNodes[talantData.ID].TalentData.ID)
                {
                    var talent = _talentNodes[talantData.ID];
                    OpenActivatedTalent(talent);
                }
                else
                {
                    SetOpenTalent(talantData);
                }
            }
        }

        private void SetOpenTalent(TalentData talentData)
        {
            for (int i = talentData.ID; i < _talentNodes.Count; i++)
            {
                if (talentData.ID == _talentNodes[i].TalentData.ID)
                {
                    var talent = _talentNodes[i];
                    OpenActivatedTalent(talent);
                }
            }
        }
        
        private void SetActivateTalent(TalentData talentData)
        {
            for (int i = talentData.ID; i < _talentNodes.Count; i++)
            {
                if (talentData.ID == _talentNodes[i].TalentData.ID)
                {
                    var talent = _talentNodes[i];
                    ActivatedTalent(talent);
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
