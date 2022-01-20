using JetBrains.Annotations;
using Towers;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    public class ElementSortButton : MonoBehaviour
    {
        [SerializeField]
        private TowerTab _towerTab;
        [SerializeField]
        private DamageType _damageType;

        private bool _isActive; 
        
        [UsedImplicitly]
        public void SortByDamageType()
        {
            if (_isActive)
            {
                _isActive = false;
                ResetSort();
            }
            else
            {
                _isActive = true;
                _towerTab.DamageTypeSimilaritySearch(_damageType);
            }
        }
        
        private void ResetSort()
        {
            _towerTab.ResetSorting();
        }
    }
}