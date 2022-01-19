using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public abstract class ViewBestiaryItem<T> : MonoBehaviour where T : Item
    {
        public BestiaryItem<T> BestiaryItem => _bestiaryItem;

        [SerializeField]
        private Image _iconItem;
        [SerializeField]
        private TextMeshProUGUI _nameItem;

        private BestiaryItem<T> _bestiaryItem;

        public void Initialize(BestiaryItem<T> bestiaryItem)
        {
            _bestiaryItem = bestiaryItem;
            
            _iconItem.sprite = bestiaryItem.Item.Sprite;
            _nameItem.text = bestiaryItem.Item.Name;
        }
    }
}