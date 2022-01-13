using System;
using JetBrains.Annotations;
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
        [SerializeField]
        private Color _selectedColor;
        [Header("Description view")]
        [SerializeField]
        private TextMeshProUGUI _textDescription;
        [SerializeField]
        private GameObject _description;
        
        private Color _defaultColor;
        private Modifier _modifier;


        public void Initialize(Modifier modifier)
        {
            _modifier = modifier;
            _modifier.IsActive = false;

            _defaultColor = _imageButton.color;

            _textDescription.text = _modifier.Description;
            _description.SetActive(false);
        }

        [UsedImplicitly]
        public void Click()
        {
            _modifier.IsActive = !_modifier.IsActive;
            _imageButton.color = _modifier.IsActive ? _selectedColor : _defaultColor;
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
