using ScreenManager;

namespace ScriptsLevels.ContextScreen
{
    public class VictoryScreenContext : BaseContext
    {
        public bool IsPassedEasyLevel { get; private set; }
        public bool IsPassedAverageLevel { get; private set; }
        public bool IsPassedHighLevel { get; private set; }

        public VictoryScreenContext(bool isPassedEasyLevel, bool isPassedAverageLevel, bool isPassedHighLevel)
        {
            IsPassedEasyLevel = isPassedEasyLevel;
            IsPassedAverageLevel = isPassedAverageLevel;
            IsPassedHighLevel = isPassedHighLevel;
        }
    }
}