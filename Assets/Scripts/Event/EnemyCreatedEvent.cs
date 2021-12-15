using EnemyComponent;
using SimpleEventBus.Events;

namespace Event
{
    public class EnemyCreatedEvent : EventBase
    {
        public Enemy Enemy { get; }

        public EnemyCreatedEvent(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}