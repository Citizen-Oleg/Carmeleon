using System;
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
        
        public void TakeDamage(int damage)
        {
            _currentHP -= damage;
            _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
            OnDamage?.Invoke();
            if (_currentHP <= 0)
            {
                //TODO: Экран проигрыша
            }
        }
    }
}
