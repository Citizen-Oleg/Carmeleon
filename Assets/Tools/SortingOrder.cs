using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tools
{
    [RequireComponent(typeof(SortingGroup))]
    public class SortingOrder : MonoBehaviour
    {
        private SortingGroup _sortingGroup;
        
        private void Awake()
        {
            _sortingGroup = gameObject.GetComponent<SortingGroup>();
        }

        private void Update()
        {
            _sortingGroup.sortingOrder = (int) -transform.position.y;
        }
    }
}