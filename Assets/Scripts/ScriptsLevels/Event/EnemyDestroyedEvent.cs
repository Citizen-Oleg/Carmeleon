using EnemyComponent;
using SimpleEventBus.Events;

namespace Event
{
    public class EnemyDestroyedEvent : EventBase
    {
        public Enemy Enemy { get; } 

        public EnemyDestroyedEvent(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}