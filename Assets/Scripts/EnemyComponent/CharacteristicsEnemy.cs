using UnityEngine;

namespace EnemyComponent
{
    /// <summary>
    /// Класс хранящий в себе данные о характеристиках врага
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class CharacteristicsEnemy : MonoBehaviour
    {
        public int MaxHp
        {
            get => _maxHP;
            set => _maxHP = value;
        }
        public int CurrentHp
        {
            get => _currentHP;
            set => _currentHP = Mathf.Clamp(value, 0 , MaxHp);
        }
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        public int Armor
        {
            get => _armor;
            set => _armor = value;
        }
        public int FireResistance
        {
            get => _fireResistance;
            set => _fireResistance = value;
        }
        public int EarthResistance
        {
            get => _earthResistance;
            set => _earthResistance = value;
        }
        public int WaterResistance
        {
            get => _waterResistance;
            set => _waterResistance = value;
        }
        public int AirResistance
        {
            get => _airResistance;
            set => _airResistance = value;
        }
        public int DamageToBase
        {
            get => _damageToBase;
            set => _damageToBase = value;
        }
        public bool IsDeath
        {
            get => _isDeath;
            set => _isDeath = value;
        }

        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private int _currentHP;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private int _damageToBase;
        [SerializeField]
        private bool _isDeath;

        [Header("Указываются проценты защиты от типа урона")]
        [Range(-100, 100)]
        [SerializeField]
        private int _armor;
        [Range(-100, 100)]
        [SerializeField]
        private int _fireResistance;
        [Range(-100, 100)]
        [SerializeField]
        private int _earthResistance;
        [Range(-100, 100)]
        [SerializeField]
        private int _waterResistance;
        [Range(-100, 100)]
        [SerializeField]
        private int _airResistance;
    }
}
