using ScreenManager;
using ScriptsLevels.Providers;
using ScriptsMenu.ContextScreen;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScriptsMenu.Map
{
    /// <summary>
    /// UI элеемент, при клике открывается окно, где можно начать игру, выбрать модификаторы для уровня.
    /// </summary>
    public class Level : MonoBehaviour, IPointerClickHandler
    {
        public LevelData LevelData => _levelData;
        public Sprite LevelMap => _levelMap;
        
        [SerializeField]
        private Sprite _levelMap;
        [SerializeField]
        private LevelData _levelData;
        [SerializeField]
        private Level _nextLevel;
        [Header("UI data")]
        [SerializeField]
        private Image _level;

        private ScreenManager.ScreenManager _screenManager;

        private void Start()
        {
            _screenManager = GameManager.ScreenManager;
            Refresh();
        }

        public void OpenLevel()
        {
            _levelData.IsOpen = true;
            gameObject.SetActive(true);
        }

        public void OpenNextLevel()
        {
            if (_nextLevel != null)
            {
                _nextLevel.OpenLevel();
            }
        }

        public void Refresh()
        {
            gameObject.SetActive(_levelData.IsOpen);
            
            var spriteProvider = GameManager.SpriteProvider;
            if (_levelData.HasGoldBorder)
            {
                _level.sprite = spriteProvider.GetSpriteByType(SpriteType.GoldLevel);
                return;
            }

            _level.sprite = spriteProvider.GetSpriteByType(_levelData.IsPassedEasyLevel ? SpriteType.PassedLevel : SpriteType.FailedLevel);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_screenManager.IsScreenOpened(ScreenType.LevelScreen) && _levelData.IsOpen)
            {
                _screenManager.CloseTopScreen();
                _screenManager.OpenScreenWithContext(ScreenType.LevelScreen, new LevelContext(this));
                return;
            }
            
            if (_levelData.IsOpen)
            {
                _screenManager.OpenScreenWithContext(ScreenType.LevelScreen, new LevelContext(this));
            }
        }
    }
}