using System.Collections;
using ScreenManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LoadingController : MonoBehaviour
    {
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
                yield return null;
            }
            
            GameManager.ScreenManager.CloseTopScreen();
        }
    }
}