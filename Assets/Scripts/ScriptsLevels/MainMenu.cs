using JetBrains.Annotations;
using ScreenManager;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptsLevels
{
    public class MainMenu : MonoBehaviour
    {
        [UsedImplicitly]
        public void NewGame()
        {
            GameManager.PlayerData.StartNewLevel();
            SceneManager.LoadScene(GlobalConstant.NAME_START_SCENE);
        }
        
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
