using ScreenManager;

namespace ScriptsMenu.ContextScreen
{
    public class LevelContext : BaseContext
    {
        public ScriptsMenu.Map.Level Level { get; }

        public LevelContext(ScriptsMenu.Map.Level level)
        {
            Level = level;
        }
    }
}
