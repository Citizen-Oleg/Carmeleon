using System.Collections.Generic;
using System.Linq;
using ResourceManager;
using ResourceView;
using ScriptsLevels.Level;
using UnityEngine;

namespace ScriptsLevels.ResourceView
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceLabel> _resourceLabels;

        protected List<Resource> _resources;
        
        protected ResourceManager.ResourceManager _resourceManager;
        
        protected virtual void Start()
        {
            _resourceManager = LevelManager.ResourceManagerLevel;
            _resources = _resourceManager.GetResources();
            _resourceManager.OnResourceChange += OnResourceAmountChanged;
            UpdateResourcesAmount();
        }

        private void OnDestroy()
        {
            _resourceManager.OnResourceChange -= OnResourceAmountChanged;
        }

        protected void OnResourceAmountChanged(Resource resource)
        {
            var index = _resourceLabels.FindIndex(resourceLabel => resourceLabel.Type == resource.Type);
            _resourceLabels[index].SetAmount(resource.Amount);
        }

        protected void UpdateResourcesAmount()
        {
            foreach (var resourceLabel in _resourceLabels)
            {
                foreach (var resource in _resources.Where(resource => resourceLabel.Type == resource.Type))
                {
                    resourceLabel.Label.text = resource.Amount.ToString();
                }
            }
        }
    }
}
