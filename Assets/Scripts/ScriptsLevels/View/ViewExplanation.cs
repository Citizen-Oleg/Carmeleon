using TMPro;
using UnityEngine;

namespace View
{
    public class ViewExplanation : MonoBehaviour
    {
        public bool IsOpen => gameObject.activeSelf;
        public RectTransform RectTransform
        {
            get => _rectTransform;
            set => _rectTransform = value;
        }

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