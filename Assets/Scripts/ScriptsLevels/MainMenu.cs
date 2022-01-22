using JetBrains.Annotations;
using ScreenManager;
using UnityEditor;
using UnityEngine;

namespace ScriptsLevels
{
    public class MainMenu : MonoBehaviour
    {
        [UsedImplicitly]
        public void OpenBestiary()
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.BestiaryScreen);
        }

        [UsedImplicitly]
        public void Exit()
        {
#if UNITY_EDITOR
           EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
