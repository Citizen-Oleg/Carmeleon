using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceManager
{
    /// <summary>
    /// Класс управляющий ресурсами
    /// </summary>
    public abstract class ResourceManager : MonoBehaviour
    {
        public event Action<Resource> OnResourceChange;
        
        [SerializeField]
        private List<Resource> _resources;

        public void AddResource(Resource resource)
        {
            AddResource(resource.Type, resource.Amount);
        }
        
        public void AddResource(ResourceType resourceType, int amount)
        {
            var index = GetIndexResource(resourceType);
            var resource = _resources[index];

            resource.Amount += amount;
            _resources[index] = resource;
            
            OnResourceChange?.Invoke(_resources[index]);
        }

        public void Pay(ResourceType resourceType, int amount)
        {
            var index = GetIndexResource(resourceType);
            var resource = _resources[index];

            resource.Amount -= amount;
            _resources[index] = resource;
                
            OnResourceChange?.Invoke(_resources[index]);
        }

        public void Pay(Resource resource)
        {
            Pay(resource.Type, resource.Amount);
        }

        public bool HasEnough(ResourceType type, int amount)
        {
            return _resources[GetIndexResource(type)].Amount >= amount;
        }

        public bool HasEnough(Resource resource)
        {
            return HasEnough(resource.Type, resource.Amount);
        }
        
        public List<Resource> GetResources()
        {
            return _resources;
        }

        public void SetResource(List<Resource> resources)
        {
            _resources = new List<Resource>(resources);
        }
        
        private int GetIndexResource(ResourceType resourceType)
        {
            return _resources.FindIndex(resource => resource.Type == resourceType);
        }
    }
}
