using ScriptsLevels.Bestiary.Tab;
using ScriptsLevels.Inventory;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class TowerTab : Tab<TowerItem, BestiaryItemTower>
    {
        [SerializeField]
        private Scrollbar _scrollbar;
        
        public void DamageTypeSimilaritySearch(DamageType damageType)
        {
            foreach (var towerViewBestiaryItem in _viewBestiaryItems)
            {
                var towerCharacteristics = towerViewBestiaryItem.BestiaryItem.Item.Tower.TowerCharacteristics;
                
                towerViewBestiaryItem.gameObject.SetActive(towerCharacteristics.DamageType == damageType);
            }

            _scrollbar.value = 1;
        }
    }
}