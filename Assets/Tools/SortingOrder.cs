using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tools
{
    [RequireComponent(typeof(SortingGroup))]
    public class SortingOrder : MonoBehaviour
    {
        private const int MULTIPLIER_FOR_CORRECT_LAYER = 10;
        
        private SortingGroup _sortingGroup;
        
        private void Awake()
        {
            _sortingGroup = gameObject.GetComponent<SortingGroup>();
        }

        private void Update()
        {
            _sortingGroup.sortingOrder = Mathf.RoundToInt(-transform.position.y * MULTIPLIER_FOR_CORRECT_LAYER);
        }
    }
}