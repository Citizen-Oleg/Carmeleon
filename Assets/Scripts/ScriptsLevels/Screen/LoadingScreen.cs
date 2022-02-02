using ScreenManager;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Screen
{
    public class LoadingScreen : BaseScreen
    {
        [SerializeField]
        private float _speedRotation;
        [SerializeField]
        private Image _imageSnake;
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        private void Update()
        {
            _imageSnake.transform.Rotate(Vector3.forward * _speedRotation * Time.deltaTime);
        }
    }
}
