using System;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public abstract class ViewBestiaryItem<T> : MonoBehaviour, IPointerClickHandler where T : Item
    {
        public BestiaryItem<T> BestiaryItem => _bestiaryItem;

        [SerializeField]
        private Image _iconItem;
        [SerializeField]
        private TextMeshProUGUI _nameItem;

        private Action<BestiaryItem<T>> _callBack;
        private BestiaryItem<T> _bestiaryItem;

        public void Initialize(BestiaryItem<T> bestiaryItem, Action<BestiaryItem<T>> callBack)
        {
            _bestiaryItem = bestiaryItem;
            _callBack = callBack;
            
            _iconItem.sprite = bestiaryItem.Item.Sprite;
            _nameItem.text = bestiaryItem.Item.Name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _callBack.Invoke(_bestiaryItem);
        }
    }
}