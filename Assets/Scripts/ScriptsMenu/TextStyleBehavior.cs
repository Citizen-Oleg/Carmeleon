using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScriptsMenu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextStyleBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private bool _isBoldText;
        
        private TextMeshProUGUI _textMeshProUGUI;

        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isBoldText)
            {
                _textMeshProUGUI.fontStyle = FontStyles.Bold | FontStyles.Underline;
            }
            else
            {
                _textMeshProUGUI.fontStyle = FontStyles.Underline;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        { 
            _textMeshProUGUI.fontStyle ^= FontStyles.Underline;
        }
    }
}
