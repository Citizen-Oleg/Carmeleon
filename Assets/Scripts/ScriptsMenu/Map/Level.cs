using ScreenManager;
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
        public LevelData LevelData
        {
            get => _levelData;
            set => _levelData = value;
        }

        public Level NextLevel => _nextLevel;
        public Sprite LevelMap => _levelMap;

        [SerializeField]
        private Image _goldOutline;
        [SerializeField]
        private Sprite _levelMap;
        [SerializeField]
        private LevelData _levelData;
        [SerializeField]
        private Level _nextLevel;
        [Header("UI data")]
        [SerializeField]
        private Image _level;
        [SerializeField]
        private Color _lockColor;
        [SerializeField]
        private Color _defaultColor;

        private void Start()
        {
           _goldOutline.gameObject.SetActive(_levelData.HasGoldBorder);
           _level.color = _levelData.IsOpen ? _defaultColor : _lockColor;
           Refresh();
        }

        public void OpenLevel()
        {
            _levelData.IsOpen = true;
            Refresh();
        }

        private void OpenNextLevel()
        {
            if (_nextLevel != null)
            {
                _nextLevel.OpenLevel();
            }
        }

        public void Refresh()
        {
            if (_levelData.IsPassedEasyLevel && _nextLevel != null)
            {
                OpenNextLevel();
            }

            _level.color = _levelData.IsOpen ? _defaultColor : _lockColor;
            _goldOutline.gameObject.SetActive(_levelData.HasGoldBorder);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_levelData.IsOpen)
            {
                GameManager.ScreenManager.OpenScreenWithContext(ScreenType.LevelScreen, new LevelContext(this));
            }
        }
    }
}