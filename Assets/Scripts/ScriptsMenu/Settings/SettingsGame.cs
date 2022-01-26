using System;
using UnityEngine;

namespace ScriptsMenu.Settings
{
    public class SettingsGame : MonoBehaviour
    {
        public event Action<bool> OnChangeHealthDisplay;

        public bool HasHealthDisplay
        {
            get => _hasHealthDisplay;
            set
            {
                OnChangeHealthDisplay?.Invoke(value);
                _hasHealthDisplay = value;
            }
        }

        public void SetScreenSize(int height, int width)
        {
            Screen.SetResolution(width, height, Screen.fullScreen);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        [SerializeField]
        private bool _hasHealthDisplay;
    }
}
