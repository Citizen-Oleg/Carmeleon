using System;
using Enemy;
using SimpleEventBus.Events;

namespace Event
{
    public class EnemyDestroyedEvent : EventBase
    {
        public TypeEnemy TypeEnemy { get; }
        public Enemy.Enemy Enemy { get; } 

        public EnemyDestroyedEvent(TypeEnemy typeEnemy, Enemy.Enemy enemy)
        {
            TypeEnemy = typeEnemy;
            Enemy = enemy;
        }
    }
}