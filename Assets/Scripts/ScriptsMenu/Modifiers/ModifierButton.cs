using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsMenu.Modifiers
{
    public class ModifierButton : MonoBehaviour
    {
        [SerializeField]
        private Image _imageButton;
        [SerializeField]
        private Color _selectedColor;

        private Color _defaultColor;
        private Modifier _modifier;
        
        public void Initialize(Modifier modifier)
        {
            _modifier = modifier;
            _modifier.IsActive = false;

            _defaultColor = _imageButton.color;
        }

        [UsedImplicitly]
        public void Click()
        {
            _modifier.IsActive = !_modifier.IsActive;
            _imageButton.color = _modifier.IsActive ? _selectedColor : _defaultColor;
        }
    }
}
