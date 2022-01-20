using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class CardBestiaryItem : MonoBehaviour
    {
        [SerializeField]
        private Image _artItem;
        [SerializeField]
        private TextMeshProUGUI _nameItem;
        [SerializeField]
        private TextMeshProUGUI _descriptionItem;
        [SerializeField]
        private ViewEnemyInformation _viewEnemyInformation;
        [SerializeField]
        private ViewTowerInformation _viewTowerInformation;

        public void SetBestiaryItem<T>(BestiaryItem<T> bestiaryItem) where T: Item
        {
            _artItem.sprite = bestiaryItem.Art;
            _nameItem.text = bestiaryItem.Item.Name;
            _descriptionItem.text = bestiaryItem.Description;

            switch (bestiaryItem)
            {
                case BestiaryItemTower bestiaryItemTower:
                    _viewEnemyInformation.gameObject.SetActive(false);
                    _viewTowerInformation.Initialize(bestiaryItemTower);
                    break;
                case BestiaryItemEnemy bestiaryItemEnemy:
                    _viewTowerInformation.gameObject.SetActive(false);
                    _viewEnemyInformation.Initialize(bestiaryItemEnemy);
                    break;
                default:
                    _viewEnemyInformation.gameObject.SetActive(false);
                    _viewTowerInformation.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
