using ScreenManager;
using ScriptsLevels.Providers;

namespace ScriptsLevels.ContextScreen
{
    public class VictoryScreenContext : BaseContext
    {
        public SpriteType EasyLevel { get; }
        public SpriteType AverageLevel { get; }
        public SpriteType HighLevel { get; }
        public int CountModifier { get; }

        public VictoryScreenContext(SpriteType easyLevel, SpriteType averageLevel, SpriteType hghLevel, int countModifier)
        {
            EasyLevel = easyLevel;
            AverageLevel = averageLevel;
            HighLevel = hghLevel;
            CountModifier = countModifier;
        }
    }
}