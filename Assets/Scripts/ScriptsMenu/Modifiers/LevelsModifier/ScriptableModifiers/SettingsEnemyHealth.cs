using Level.ScriptsMenu.Interface;
using ScriptsLevels.Level;
using ScriptsMenu.Modifiers.LevelsModifier.Modifiers;
using UnityEngine;

namespace ScriptsMenu.Modifiers.LevelsModifier.ScriptableModifiers
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ModifierSettings/EnemyHealth", order = 1)]
    public class SettingsEnemyHealth : Modifier
    {
        [Range(0f, 200f)]
        [SerializeField]
        private float _increasePercentage;
        
        public override IModifier GetModificator()
        {
            var levelSettings = LevelManager.LevelSettings;
            return new EnemyHealthModifier(_increasePercentage, levelSettings);
        }
    }
}