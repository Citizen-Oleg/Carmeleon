using System;
using Enemy;
using SimpleEventBus.Events;

namespace Event
{
    public class EnemyDestroyedEvent : EventBase
    {
        public Enemy.Enemy Enemy { get; } 

        public EnemyDestroyedEvent(Enemy.Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}