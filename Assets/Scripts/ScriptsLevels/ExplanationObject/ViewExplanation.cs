using TMPro;
using UnityEngine;

namespace ScriptsLevels.ExplanationObject
{
    public class ViewExplanation : MonoBehaviour
    {
        public bool IsOpen => gameObject.activeSelf;
        public RectTransform RectTransform => _rectTransform;
        
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private GameObject _fon;
        
        public void Show(string text)
        {
            _text.text = text;
            _fon.SetActive(true);
        }

        public void Close()
        {
            _fon.SetActive(false);
        }
    }
}