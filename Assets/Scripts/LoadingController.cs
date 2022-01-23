using System.Collections;
using ScreenManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LoadingController : MonoBehaviour
    {
        public float LoadingProgress { get; private set; }
        
        public void StartLoad(string sceneName)
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.LoadingScreen);
            
            StartCoroutine(LoadCoroutine(sceneName));
        }
        
        private IEnumerator LoadCoroutine(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                LoadingProgress = Mathf.Clamp01(operation.progress / 1f);
                yield return null;
            }
            
            GameManager.ScreenManager.CloseTopScreen();
        }
    }
}