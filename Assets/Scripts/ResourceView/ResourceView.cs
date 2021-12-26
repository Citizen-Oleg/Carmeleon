using System.Collections.Generic;
using System.Linq;
using ResourceManager;
using UnityEngine;

namespace ResourceView
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceLabel> _resourceLabels;

        private List<Resource> _resources;
        
        private void Start()
        {
            _resources = LevelManager.ResourceManagerLevel.GetResources();
            LevelManager.ResourceManagerLevel.OnResourceChange += OnResourceAmountChanged;
            UpdateResourcesAmount();
        }

        private void OnDestroy()
        {
            LevelManager.ResourceManagerLevel.OnResourceChange -= OnResourceAmountChanged;
        }

        private void OnResourceAmountChanged(Resource resource)
        {
            var index = _resourceLabels.FindIndex(resourceLabel => resourceLabel.Type == resource.Type);
            _resourceLabels[index].SetAmount(resource.Amount);
        }

        private void UpdateResourcesAmount()
        {
            foreach (var resourceLabel in _resourceLabels)
            {
                foreach (var resource in _resources.Where(resource => resourceLabel.Type == resource.Type))
                {
                    resourceLabel.Label.text = resource.Amount.ToString();
                    resourceLabel.СurrentValue = resource.Amount;
                }
            }
        }
        
    }
}
