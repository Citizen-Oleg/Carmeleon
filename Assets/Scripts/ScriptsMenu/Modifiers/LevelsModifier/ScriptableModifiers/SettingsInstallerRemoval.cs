using Level.ScriptsMenu.Interface;
using ScriptsLevels.Level;
using ScriptsMenu.Modifiers.LevelsModifier.Modifiers;
using UnityEngine;

namespace ScriptsMenu.Modifiers.LevelsModifier.ScriptableModifiers
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ModifierSettings/InstallerRemoval", order = 3)]
    public class SettingsInstallerRemoval : Modifier
    {
        public override IModifier GetModificator()
        {
            var levelSettings = LevelManager.LevelSettings;
            return new InstallerRemovalModifier(levelSettings);
        }
    }
}