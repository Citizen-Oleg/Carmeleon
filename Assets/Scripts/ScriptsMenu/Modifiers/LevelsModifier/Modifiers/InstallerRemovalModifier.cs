using Level.ScriptsMenu.Interface;
using ScriptsLevels.Level;

namespace ScriptsMenu.Modifiers.LevelsModifier.Modifiers
{
    public class InstallerRemovalModifier : IModifier
    {
        private readonly LevelSettings _levelSettings;

        public InstallerRemovalModifier(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }
        
        public void Activate()
        {
            foreach (var placeInstallationTower in _levelSettings.DestructionSiteInstallationTower)
            {
                placeInstallationTower.gameObject.SetActive(false);
            }
        }
    }
}