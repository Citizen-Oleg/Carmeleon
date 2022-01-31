    using System;
using JetBrains.Annotations;
    using ScriptsLevels.Providers;
    using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScriptsMenu.Modifiers
{
    public class ModifierButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Image _imageButton;
     
        [Header("Description view")]
        [SerializeField]
        private TextMeshProUGUI _textDescription;
        [SerializeField]
        private GameObject _description;
        
        private ModifierData _modifier;
        
        public void Initialize(ModifierData modifier)
        {
            _modifier = modifier;
            _modifier.IsActive = false;

            _textDescription.text = _modifier.Modifier.Description;
            _description.SetActive(false);
            
            SetSpriteModifier();
        }

        [UsedImplicitly]
        public void Click()
        {
            _modifier.IsActive = !_modifier.IsActive;
            SetSpriteModifier();
        }

        private void SetSpriteModifier()
        {
            var spriteProvider = GameManager.SpriteProvider;
            
            switch (_modifier.IsActive)
            {
                case true when !_modifier.IsPassed:
                    _imageButton.sprite = spriteProvider.GetSpriteByType(SpriteType.FailedSelectedModifier);
                    break;
                case false when _modifier.IsPassed:
                    _imageButton.sprite = spriteProvider.GetSpriteByType(SpriteType.PassedModifier);
                    break;
            }

            switch (_modifier.IsActive)
            {
                case true when _modifier.IsPassed:
                    _imageButton.sprite = spriteProvider.GetSpriteByType(SpriteType.PassedSelectedModifier);
                    break;
                case false when !_modifier.IsPassed:
                    _imageButton.sprite = spriteProvider.GetSpriteByType(SpriteType.FailedModifier);
                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _description.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _description.SetActive(false);
        }
    }
}
