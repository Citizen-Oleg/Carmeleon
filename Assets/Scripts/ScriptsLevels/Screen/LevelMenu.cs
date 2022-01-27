using JetBrains.Annotations;
using ScreenManager;
using ScriptsLevels.Level;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Screen
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField]
        private Toggle _toggleFullScreen;
        [SerializeField]
        private Toggle _toggleHealthDisplay;

        private void Start()
        {
            _toggleFullScreen.isOn = UnityEngine.Screen.fullScreen;
            _toggleHealthDisplay.isOn = GameManager.SettingsGame.HasHealthDisplay;
        }

        [UsedImplicitly]
        public void ChangeHealthDisplay(bool hasHealthDisplay)
        {
            GameManager.SettingsGame.HasHealthDisplay = hasHealthDisplay;
        }

        [UsedImplicitly]
        public void ChangeFullScreen(bool hasFullScreen)
        {
            GameManager.SettingsGame.SetFullScreen(hasFullScreen);
        }

        [UsedImplicitly]
        public void OpenBestiary()
        {
            LevelManager.instance.SetState(StateLevel.Pause);
            GameManager.ScreenManager.OpenScreen(ScreenType.BestiaryScreen);
        }

        [UsedImplicitly]
        public void RestartLevel()
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.RestartView);
        }

        [UsedImplicitly]
        public void ExitToMenu()
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.ExitView);
        }
    }
}
