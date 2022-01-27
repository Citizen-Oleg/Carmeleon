using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;

namespace ScriptsLevels.Screen
{
    public class ExitView : BaseScreen
    {
        private void Start()
        {
            LevelManager.instance.SetState(StateLevel.Pause);
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            GameManager.ScreenManager.CloseTopScreen();
            GameManager.LoadingController.StartLoad(GlobalConstant.NAME_START_SCENE);
        }

        [UsedImplicitly]
        public void Close()
        {
            LevelManager.instance.SetState(StateLevel.Normal);
            GameManager.ScreenManager.CloseTopScreen();
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}