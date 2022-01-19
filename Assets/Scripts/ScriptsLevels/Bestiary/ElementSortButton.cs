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

        [UsedImplicitly]
        public void Click()
        {
            _towerTab.DamageTypeSimilaritySearch(_damageType);
        }
    }
}