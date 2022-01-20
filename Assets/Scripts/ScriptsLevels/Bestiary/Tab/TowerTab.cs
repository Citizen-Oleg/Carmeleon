using ScriptsLevels.Bestiary.Tab;
using ScriptsLevels.Inventory;
using Towers;

namespace ScriptsLevels.Bestiary
{
    public class TowerTab : Tab<TowerItem, BestiaryItemTower>
    {
        public void DamageTypeSimilaritySearch(DamageType damageType)
        {
            foreach (var towerViewBestiaryItem in _viewBestiaryItems)
            {
                var towerCharacteristics = towerViewBestiaryItem.BestiaryItem.Item.Tower.TowerCharacteristics;
                
                towerViewBestiaryItem.gameObject.SetActive(towerCharacteristics.DamageType == damageType);
            }
        }
    }
}