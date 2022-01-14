using ResourceManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptsMenu.Tree
{
    public class TalentNode : MonoBehaviour, IPointerClickHandler
    {
        public TalentData TalentData => _talentData;

        [SerializeField]
        private Resource _price;
        [SerializeField]
        private TreeTalent _treeTalent;
        [SerializeField]
        private TalentData _talentData;
        [SerializeField]
        private TalentNode _nextTalentNode;

        private ResourceManagerGame _resourceManagerGame;
        
        private void Start()
        {
            _resourceManagerGame = GameManager.ResourceManagerGame;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (_talentData.IsOpen && !_talentData.IsActive && _resourceManagerGame.HasEnough(_price))
                {
                    _treeTalent.ActivatedTalent(this);
                    GameManager.PlayerData.AddActivatedNode(this);
                }
            }
        }

        public void OpenTalent()
        {
            _talentData.IsOpen = true;
            Refresh();
        }

        public void CloseTalent()
        {
            _talentData.IsOpen = false;
            Refresh();
        }

        public void Refresh()
        {
        }
        
        public void OpenNextTalent()
        {
            _nextTalentNode.OpenTalent();
        }
    }
}