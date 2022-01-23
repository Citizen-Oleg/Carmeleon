using ScreenManager;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Screen
{
    public class LoadingScreen : BaseScreen
    {
        [SerializeField]
        private Slider _loadingProgress;
        
        private void Update()
        {
            _loadingProgress.value = GameManager.LoadingController.LoadingProgress;
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}
