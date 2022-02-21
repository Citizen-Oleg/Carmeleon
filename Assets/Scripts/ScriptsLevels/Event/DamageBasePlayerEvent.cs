using SimpleEventBus.Events;

namespace ScriptsLevels.Event
{
    public class DamageBasePlayerEvent : EventBase
    {
        public int Damage { get;}

        public DamageBasePlayerEvent(int damage)
        {
            Damage = damage;
        }
    }
}