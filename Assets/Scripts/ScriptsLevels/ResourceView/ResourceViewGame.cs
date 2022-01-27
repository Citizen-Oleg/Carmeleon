using UnityEngine;

namespace ScriptsLevels.ResourceView
{
    public class ResourceViewGame : ResourceView
    {
        protected override void Start()
        {
            _resourceManager = GameManager.ResourceManagerGame;
            _resources = _resourceManager.GetResources();
            _resourceManager.OnResourceChange += OnResourceAmountChanged;
            UpdateResourcesAmount();
        }
    }
}
