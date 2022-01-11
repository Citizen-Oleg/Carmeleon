using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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

        [SerializeField]
        private Image _goldOutline;
        [SerializeField]
        private LevelData _levelData;
        [SerializeField]
        private Level _nextLevel;

        private void Start()
        {
           // _goldOutline.gameObject.SetActive(false);
        }

        [UsedImplicitly]
        public void StartGame()
        {
            GameManager.instance.CurrentLevel = this;
            SceneManager.LoadScene(LevelData.NameScene);
        }

        public void OpenLevel()
        {
            _levelData.IsOpen = true;
        }

        private void OpenNextLevel()
        {
            _nextLevel.OpenLevel();
        }

        public void Refresh()
        {
            if (_levelData.IsPassedEasyLevel && _nextLevel != null)
            {
                OpenNextLevel();
            }

            if (_levelData.IsPassedHighLevel)
            {
                //_goldOutline.gameObject.SetActive(true);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            StartGame();
        }
    }
}