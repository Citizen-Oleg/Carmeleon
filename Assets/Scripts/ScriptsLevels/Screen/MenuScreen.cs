using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;
using UnityEngine.SceneManagement;

namespace ScriptsLevels.Screen
{
    public class MenuScreen : BaseScreen
    {
        private ScreenManager.ScreenManager _screenManager;
        
        private void Awake()
        {
            _screenManager = GameManager.ScreenManager;
        }

        public override void Initialize(ScreenType screenType)
        {
            LevelManager.instance.SetState(StateLevel.Pause);
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void Continue()
        {
            _screenManager.CloseTopScreen();
            LevelManager.instance.SetState(StateLevel.Normal);
        }

        [UsedImplicitly]
        public void OpenBestiary()
        {
            _screenManager.OpenScreen(ScreenType.BestiaryScreen);
        }

        [UsedImplicitly]
        public void Restart()
        {
            _screenManager.CloseTopScreen();
            var sceneName = GameManager.instance.CurrentLevel.LevelData.NameScene;
            GameManager.LoadingController.StartLoad(sceneName);
        }

        [UsedImplicitly]
        public void ReturnToMenu()
        {
            _screenManager.CloseTopScreen();
            GameManager.LoadingController.StartLoad(GlobalConstant.NAME_START_SCENE);
        }
    }
}