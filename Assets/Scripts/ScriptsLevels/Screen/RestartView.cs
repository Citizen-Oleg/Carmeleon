using System;
using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;

namespace ScriptsLevels.Screen
{
    public class RestartView : BaseScreen
    {
        private void Start()
        {
            LevelManager.instance.SetState(StateLevel.Pause);
        }

        [UsedImplicitly]
        public void BackToMenu()
        {
            GameManager.ScreenManager.CloseTopScreen();
            GameManager.LoadingController.StartLoad(GameManager.instance.CurrentLevel.LevelData.NameScene);
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
