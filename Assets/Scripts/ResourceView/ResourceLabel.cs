using ResourceManager;
using TMPro;
using UnityEngine;

namespace ResourceView
{
    public class ResourceLabel : MonoBehaviour
    {
        public ResourceType Type => _type;
        public TextMeshProUGUI Label => _label;

        public int СurrentValue
        {
            set => _currentValue = value;
        }
    
        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private TextMeshProUGUI _label;
        private int _currentValue;

        public void SetAmount(int newAmount)
        {
            _currentValue = newAmount;
            Label.text = newAmount.ToString();
        }
    }
}
