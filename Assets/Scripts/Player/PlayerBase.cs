using UnityEngine;

namespace Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private int _currentHP;
        
        public void TakeDamage(int damage)
        {
            _currentHP -= damage;
            _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
            if (_currentHP <= 0)
            {
                //TODO: Экран проигрыша
            }
        }
    }
}
