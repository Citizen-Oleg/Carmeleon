using Level.ScriptsMenu.Interface;
using ScriptsLevels.Level;

namespace ScriptsMenu.Modifiers.LevelsModifier.Modifiers
{
    public class EnemyHealthModifier : IModifier
    {
        private readonly float _increasePercentage;
        private readonly LevelSettings _levelSettings;
        
        public EnemyHealthModifier(float increasePercentage, LevelSettings levelSettings)
        {
            _increasePercentage = increasePercentage;
            _levelSettings = levelSettings;
        }

        public void Activate()
        {
            _levelSettings.PercentageIncreaseHealth += _increasePercentage;
        }
    }
}