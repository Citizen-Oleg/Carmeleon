using Inventory;
using ScriptsLevels.Bestiary.Tab;
using TMPro;
using UnityEngine;

namespace ScriptsLevels.Bestiary.FindField
{
    public abstract class FindField<T, TB> : MonoBehaviour
        where T : Item
        where TB : BestiaryItem<T>
    {
        [SerializeField]
        private Tab<T, TB> _tab;

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
