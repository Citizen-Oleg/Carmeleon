using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;
using UnityEngine.SceneManagement;

namespace ScriptsLevels.Screen
{
    public class MenuScreen : BaseScreen
    {
        public override void Initialize(ScreenType screenType)
        {
            LevelManager.instance.SetState(StateLevel.Pause);
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void Continue()
        {
            GameManager.ScreenManager.CloseTopScreen();
            LevelManager.instance.SetState(StateLevel.Normal);
        }

        [UsedImplicitly]
        public void Restart()
        {
            GameManager.ScreenManager.CloseTopScreen();
            SceneManager.LoadScene(GameManager.instance.CurrentLevel.LevelData.NameScene);
        }

        [UsedImplicitly]
        public void ReturnToMenu()
        {
            GameManager.ScreenManager.CloseTopScreen();
            SceneManager.LoadScene(GlobalConstant.NAME_START_SCENE);
        }
    }
}