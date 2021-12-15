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

        public void AddResource(ResourceType resourceType, int amount)
        {
            var index = GetIndexResource(resourceType);
            var resource = _resources[index];

            resource.Amount += amount;
            _resources[index] = resource;
            
            OnResourceChange?.Invoke(resource);
        }

        public void Pay(ResourceType resourceType, int amount)
        {
            var index = GetIndexResource(resourceType);
            var resource = _resources[index];

            resource.Amount -= amount;
            _resources[index] = resource;
                
            OnResourceChange?.Invoke(resource);
        }

        public bool HasEnough(ResourceType type, int amount)
        {
            return _resources[GetIndexResource(type)].Amount >= amount;
        }
        
        private int GetIndexResource(ResourceType resourceType)
        {
            return _resources.FindIndex(resource => resource.Type == resourceType);
        }
    }
}