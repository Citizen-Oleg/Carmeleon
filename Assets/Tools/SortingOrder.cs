using UnityEngine;

namespace Tools
{
    public class SortingOrder : MonoBehaviour
    {
        private Renderer _renderer;
        
        [ContextMenu("SortgingOredLayer")]
        private void SortingOrderLayer()
        {
            _renderer = gameObject.GetComponent<Renderer>();
            _renderer.sortingOrder = (int) transform.position.y;
        }
    }
}