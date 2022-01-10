using Level;
using Level.ScriptsMenu.Interface;

namespace ScriptsMenu.Modifiers.LevelsModifier.Modificators
{
    public class ModificatorLevel : IModifier
    {
        private LevelSettings _levelSettings;

        public ModificatorLevel(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }
        
        public void Activate()
        {
            throw new System.NotImplementedException();
        }
    }
}
