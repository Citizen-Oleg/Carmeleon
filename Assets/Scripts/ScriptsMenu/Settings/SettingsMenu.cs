using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsMenu.Settings
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField]
        private List<ScreenData> _screenDatas = new List<ScreenData>();
        [SerializeField]
        private TMP_Dropdown _dropdown;
        [SerializeField]
        private Toggle _toggleFullScreen;
        [SerializeField]
        private Toggle _toggleHealthDisplay;

        private SettingsGame _settingsGame;

        private void Start()
        {
            _settingsGame = GameManager.SettingsGame;
            _toggleFullScreen.isOn = Screen.fullScreen;
            _toggleHealthDisplay.isOn = GameManager.SettingsGame.HasHealthDisplay;
            FillDropDown();
            SetCurrentScreen();
        }
        
        [UsedImplicitly]
        public void ChangeScreenSize(int id)
        {
            var screenData = _screenDatas[id];
            _settingsGame.SetScreenSize(screenData.Height, screenData.Width);
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

        private void SetCurrentScreen()
        {
            var currentSize = Screen.currentResolution;
           
            var index = 0;
            for (int i = 0; i < _screenDatas.Count; i++)
            {
                if (_screenDatas[i].Height == currentSize.height && _screenDatas[i].Width == currentSize.width)
                {
                    index = i;
                    break;
                }
            }

            _dropdown.captionText.text = _dropdown.options[index].text;
            _dropdown.value = index;
        }

        private void FillDropDown()
        {
            foreach (var screenData in _screenDatas)
            {
                var option = new TMP_Dropdown.OptionData
                {
                    text = screenData.Width + "x" + screenData.Height
                };
                
                _dropdown.options.Add(option);
            }
        }
    }
}
