using JetBrains.Annotations;
using ScreenManager;
using ScriptsMenu.ContextScreen;
using ScriptsMenu.Modifiers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ScriptsLevels.Screen
{
    public class LevelScreen : BaseScreenWithContext<LevelContext>
    {
        [SerializeField]
        private ModifierButton _modifierButtonPrefab;
        [SerializeField]
        private Transform _containerModifier;
        
        [SerializeField]
        private Image _levelMap;
        
        [Header("Text information")]
        [SerializeField]
        private TextMeshProUGUI _nameLevel;
        [SerializeField]
        private TextMeshProUGUI _description;

        [Header("Splinter")]
        [SerializeField]
        private Color _receiptColor;
        [SerializeField]
        private Color _nonReceivedColor;
        [SerializeField]
        private Image _easeSplinter;
        [SerializeField]
        private Image _averageSplinter;
        [SerializeField]
        private Image _highSplinter;

        private ScriptsMenu.Map.Level _level;
        
        public override void ApplyContext(LevelContext context)
        {
            _level = context.Level;

            _nameLevel.text = _level.LevelData.NameLevel;
            _description.text = _level.LevelData.Description;

            _levelMap.sprite = _level.LevelMap;
            
            CreateModifier();
            ShowSplinter();
        }
        
        [UsedImplicitly]
        public void StartGame()
        {
            GameManager.instance.CurrentLevel = _level;
            GameManager.ScreenManager.CloseTopScreen();
            SceneManager.LoadScene(_level.LevelData.NameScene);
        }

        [UsedImplicitly]
        public void Close()
        {
            GameManager.ScreenManager.CloseTopScreen();
        }

        private void ShowSplinter()
        {
            var levelData = _level.LevelData;
            _easeSplinter.color = levelData.IsPassedEasyLevel ? _receiptColor : _nonReceivedColor;
            _averageSplinter.color = levelData.IsPassedAverageLevel ? _receiptColor : _nonReceivedColor;
            _highSplinter.color = levelData.IsPassedHighLevel ? _receiptColor : _nonReceivedColor;
        }

        private void CreateModifier()
        {
            foreach (var modifier in _level.LevelData.Modifiers)
            {
                var modifierButton = Instantiate(_modifierButtonPrefab, _containerModifier);
                modifierButton.Initialize(modifier);
            }
        }

        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }
    }
}