using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.ContextScreen;
using ScriptsLevels.Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScriptsLevels.Screen
{
    public class VictoryScreen : BaseScreenWithContext<VictoryScreenContext>
    {
        [SerializeField]
        private Image _easySplinter;
        [SerializeField]
        private Image _averageSplinter;
        [SerializeField]
        private Image _highSplinter;

        private ScreenManager.ScreenManager _screenManager;
        private void Start()
        {
            _screenManager = GameManager.ScreenManager;
            LevelManager.instance.SetState(StateLevel.Pause);
        }

        public override void ApplyContext(VictoryScreenContext context)
        {
            _easySplinter.gameObject.SetActive(context.IsPassedEasyLevel);
            _averageSplinter.gameObject.SetActive(context.IsPassedAverageLevel);
            _highSplinter.gameObject.SetActive(context.IsPassedHighLevel);
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            SceneManager.LoadScene(GlobalConstant.NAME_START_SCENE);
            _screenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public void Restart()
        {
            SceneManager.LoadScene(GameManager.instance.CurrentLevel.LevelData.NameScene);
            _screenManager.CloseTopScreen();
        }
    }
}
