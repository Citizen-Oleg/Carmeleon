using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;
using UnityEngine.SceneManagement;

namespace ScriptsLevels.Screen
{
    public class LoseScreen : BaseScreen
    {
        private ScreenManager.ScreenManager _screenManager;
        private void Start()
        {
            _screenManager = GameManager.ScreenManager;
            LevelManager.instance.SetState(StateLevel.Pause);
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void Restart()
        {
            GameManager.LoadingController.StartLoad(GameManager.instance.CurrentLevel.LevelData.NameScene);
            _screenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            GameManager.LoadingController.StartLoad(GlobalConstant.NAME_START_SCENE);
            _screenManager.CloseTopScreen();
        }
    }
}