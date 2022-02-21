using System;
using ScriptsLevels.Event;
using SimpleEventBus;
using UnityEngine;

namespace Player
{
    public class PlayerBase : MonoBehaviour
    {
        public event Action OnDamage;
        
        public int MAXHp => _maxHP;
        public int CurrentHp => _currentHP;

        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private int _currentHP;

        private IDisposable _subsriber;
        
        private void Awake()
        {
            _subsriber = EventStreams.UserInterface.Subscribe<DamageBasePlayerEvent>(TakeDamage);
        }

        public void TakeDamage(DamageBasePlayerEvent damageEvent)
        {
            _currentHP -= damageEvent.Damage;
            _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
            OnDamage?.Invoke();
            if (_currentHP <= 0)
            {
                EventStreams.UserInterface.Publish(new EventCompletingLevel());
            }
        }

        private void OnDestroy()
        {
            _subsriber?.Dispose();
        }
    }
}
