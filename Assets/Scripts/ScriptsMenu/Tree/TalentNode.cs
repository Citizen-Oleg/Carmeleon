using ResourceManager;
using ScriptsLevels.Providers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScriptsMenu.Tree
{
    public class TalentNode : MonoBehaviour, IPointerClickHandler
    {
        public TalentData TalentData => _talentData;
        public Resource Price => _price;

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
        private Image _imageState;
        [SerializeField]
        private TextMeshProUGUI _textPrice;
        [SerializeField]
        private TextMeshProUGUI _descriptionTalent;
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
                    GameManager.PlayerData.AddActivatedNode(_talentData);
                    _resourceManagerGame.Pay(_price);
                }
            }
        }

        public void OpenTalent()
        {
            _talentData.IsOpen = true;
        }

        public void CloseTalent()
        {
            _talentData.IsOpen = false;
        }

        public void Refresh()
        {
            var spriteProvider = GameManager.SpriteProvider;

            _textPrice.gameObject.SetActive(!_talentData.IsActive);
            if (!_talentData.IsOpen)
            {
                _nodeImage.color = _closeColor;
                _imageTalent.color = _closeColor;
                _imageState.sprite = spriteProvider.GetSpriteByType(SpriteType.OpenTalent);
                _textPrice.text = _price.Amount.ToString();
                return;
            }
            
            _nodeImage.color = _openColor;
            _imageTalent.color = _openColor;
            _descriptionTalent.text = _talentData.Talent.Description;
            
            if (_talentData.IsActive)
            {
                _imageState.sprite = spriteProvider.GetSpriteByType(SpriteType.BoughtTalent);
                return;
            }
            
            if (_talentData.IsOpen)
            {
                _imageState.sprite = spriteProvider.GetSpriteByType(SpriteType.OpenTalent);
                _textPrice.text = _price.Amount.ToString();
            }
        }
        
        public void OpenNextTalent()
        {
            if (_nextTalentNode != null)
            {
                _nextTalentNode.OpenTalent();
                _nextTalentNode.Refresh();
            }
        }

        public void CloseNextTalent()
        {
            if (_nextTalentNode != null)
            {
                _nextTalentNode.CloseTalent();
                _nextTalentNode.Refresh();
            }
        }
    }
}