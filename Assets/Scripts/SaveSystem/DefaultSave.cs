using System.Collections.Generic;
using ResourceManager;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObjects/DefaultSave", order = 0)]
    public class DefaultSave : ScriptableObject
    {
        public List<Resource> Resources => _resources;

        [SerializeField]
        private List<Resource> _resources = new List<Resource>();
    }
}