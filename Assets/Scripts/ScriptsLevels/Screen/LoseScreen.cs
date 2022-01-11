using JetBrains.Annotations;
using ScreenManager;
using UnityEngine.SceneManagement;

namespace ScriptsLevels.Screen
{
    public class LoseScreen : BaseScreen
    {
        private ScreenManager.ScreenManager _screenManager;
        private void Start()
        {
            _screenManager = GameManager.ScreenManager;
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        [UsedImplicitly]
        public void Restart()
        {
            SceneManager.LoadScene(GameManager.instance.CurrentLevel.LevelData.NameScene);
            _screenManager.CloseTopScreen();
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            SceneManager.LoadScene(GlobalConstant.NAME_START_SCENE);
            _screenManager.CloseTopScreen();
        }
    }
}