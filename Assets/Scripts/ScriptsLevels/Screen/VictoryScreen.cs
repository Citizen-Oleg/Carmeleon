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
            var spriteProvider = GameManager.SpriteProvider;
            _easySplinter.sprite = spriteProvider.GetSpriteByType(context.EasyLevel);
            _averageSplinter.sprite = spriteProvider.GetSpriteByType(context.AverageLevel);
            _highSplinter.sprite = spriteProvider.GetSpriteByType(context.HighLevel);
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            GameManager.LoadingController.StartLoad(GlobalConstant.NAME_START_SCENE);
            _screenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public void Restart()
        {
            GameManager.LoadingController.StartLoad(GameManager.instance.CurrentLevel.LevelData.NameScene);
            _screenManager.CloseTopScreen();
        }
    }
}
