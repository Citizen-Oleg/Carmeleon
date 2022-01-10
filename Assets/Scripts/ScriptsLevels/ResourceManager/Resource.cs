using System;
using UnityEngine;

namespace ResourceManager
{
    [Serializable]
    public struct Resource
    {
        public ResourceType Type
        {
            get => _type;
            set => _type = value;
        }

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        [SerializeField]
        private ResourceType _type;
        [SerializeField]
        private int _amount;
    }
}