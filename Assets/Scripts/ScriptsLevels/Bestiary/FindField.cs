using System;
using Inventory;
using TMPro;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    public class FindField : MonoBehaviour
    {
        public Tab<Item, BestiaryItem<Item>> Tab
        {
            set => _tab = value;
        }

        private Tab<Item, BestiaryItem<Item>> _tab;

        [SerializeField]
        private TMP_InputField _tmpInputField;

        private void Start()
        {
            _tmpInputField.onValueChanged.AddListener(SearchEnteredText);
        }

        private void SearchEnteredText(string text)
        {
            _tab.NameSimilaritySearch(text);
        }

        private void OnDestroy()
        {
            _tmpInputField.onValueChanged.RemoveListener(SearchEnteredText);
        }
    }
}
