using UnityEngine;

namespace Towers
{
    public class GhostTower : MonoBehaviour
    {
        public Tower PrefabTower => _prefabTower;

        [SerializeField]
        private Tower _prefabTower;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Color _permissiveColor;
        [SerializeField]
        private Color _forbiddingColor;
        
        private Color _defaultColor;
        
        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ConstructionAllowed()
        {
            _spriteRenderer.color = _permissiveColor;
        }

        public void ProhibitedConstruction()
        {
            _spriteRenderer.color = _forbiddingColor;
        }

        public void DefaultState()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}
