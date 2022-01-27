using JetBrains.Annotations;
using ScreenManager;

namespace ScriptsLevels.Screen
{
    public class ResetGameView : BaseScreen
    {
        [UsedImplicitly]
        public void ResetGame()
        {
            GameManager.ScreenManager.CloseTopScreen();
            GameManager.PlayerData.StartNewLevel();
        }

        [UsedImplicitly]
        public void Close()
        {
            GameManager.ScreenManager.CloseTopScreen();
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}