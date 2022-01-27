using ResourceManager;
using TMPro;
using UnityEngine;

namespace ResourceView
{
    public class ResourceLabel : MonoBehaviour
    {
        public ResourceType Type => _type;
        public TextMeshProUGUI Label => _label;
        
        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private TextMeshProUGUI _label;
        
        public void SetAmount(int newAmount)
        {
            Label.text = newAmount.ToString();
        }
    }
}
