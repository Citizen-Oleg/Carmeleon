using ResourceManager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

        [Header("UI data")]
        [SerializeField]
        private Image _nodeImage;
        [SerializeField]
        private Image _imageTalent;
        [SerializeField]
        private TextMeshProUGUI _descriptionTalent;
        [SerializeField]
        private Color _activeColor;
        [SerializeField]
        private Color _openColor;
        [SerializeField]
        private Color _closeColor;

        private ResourceManagerGame _resourceManagerGame;
        
        private void Start()
        {
            _resourceManagerGame = GameManager.ResourceManagerGame;

            _descriptionTalent.text = _talentData.Talent.Description;
            _imageTalent.sprite = _talentData.Talent.IconTalent;
            
            Refresh();
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
            if (_talentData.IsOpen)
            {
                _nodeImage.color = _openColor;
                _imageTalent.color = _openColor;
                _descriptionTalent.color = _openColor;
            }
            else
            {
                _nodeImage.color = _closeColor;
                _imageTalent.color = _closeColor;
                _descriptionTalent.color = _closeColor;
            }

            if (_talentData.IsActive)
            {
                _nodeImage.color = _activeColor;
            }
        }
        
        public void OpenNextTalent()
        {
            if (_nextTalentNode != null)
            {
                _nextTalentNode.OpenTalent();
            }
        }
    }
}