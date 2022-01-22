using ScreenManager;
using ScriptsLevels.Providers;

namespace ScriptsLevels.ContextScreen
{
    public class VictoryScreenContext : BaseContext
    {
        public SpriteType EasyLevel { get; }
        public SpriteType AverageLevel { get; }
        public SpriteType HighLevel { get; }

        public VictoryScreenContext(SpriteType easyLevel, SpriteType averageLevel, SpriteType hghLevel)
        {
            EasyLevel = easyLevel;
            AverageLevel = averageLevel;
            HighLevel = hghLevel;
        }
    }
}