using Inventory;
using JetBrains.Annotations;
using ScreenManager;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    public class BestiaryScreen : BaseScreen
    {
        [SerializeField]
        private CardBestiaryItem _cardBestiaryItem;
        [SerializeField]
        private GameObject _startTab;

        private void Awake()
        {
            _startTab.gameObject.SetActive(true);
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void Close()
        {
            GameManager.ScreenManager.CloseTopScreen();
        }

        public void SetBestiaryItem<T>(BestiaryItem<T> bestiaryItem) where T: Item
        {
            _cardBestiaryItem.SetBestiaryItem(bestiaryItem);
        }
    }
}