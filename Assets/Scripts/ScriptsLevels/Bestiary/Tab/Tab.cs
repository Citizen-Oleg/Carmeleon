using System.Collections.Generic;
using System.Linq;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public abstract class Tab<T, TB> : MonoBehaviour 
        where T : Item
        where TB : BestiaryItem<T>
    {
        [SerializeField]
        private FindField _findField;
        [SerializeField]
        private ViewBestiaryItem<T> _viewBestiaryItem;
        [SerializeField]
        private RectTransform _container;
        [SerializeField]
        private GridLayoutGroup _gridLayoutGroup;
        [SerializeField]
        private List<TB> _bestiaryItems = new List<TB>();

        protected readonly List<ViewBestiaryItem<T>> _viewBestiaryItems = new List<ViewBestiaryItem<T>>();
        
        private void Awake()
        {
            
            var height = _bestiaryItems.Count * _gridLayoutGroup.cellSize.y;
            _container.sizeDelta = new Vector2(_container.sizeDelta.x, height + _container.sizeDelta.y);
            
            _bestiaryItems = (from item in _bestiaryItems orderby item.Item.Name select item).ToList();
            CreateBestiaryItems();
        }
        
        private void CreateBestiaryItems()
        {
            foreach (var bestiaryItem in _bestiaryItems)
            {
                var view = Instantiate(_viewBestiaryItem, _container);
                view.Initialize(bestiaryItem);
                _viewBestiaryItems.Add(view);
            }
        }

        public void ResetSorting()
        {
            foreach (var viewBestiaryItem in _viewBestiaryItems)
            {
                viewBestiaryItem.gameObject.SetActive(true);
            }
        }

        public void NameSimilaritySearch(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                ResetSorting();
                return;
            }
            
            foreach (var viewBestiaryItem in _viewBestiaryItems)
            { 
                var contains = viewBestiaryItem.BestiaryItem.Item.Name.Contains(text);
                viewBestiaryItem.gameObject.SetActive(contains);
            }
        }
    }
}