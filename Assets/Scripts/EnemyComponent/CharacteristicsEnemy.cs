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
        public float Armor
        {
            get => _armor;
            set => _armor = value;
        }
        public float FireResistance
        {
            get => _fireResistance;
            set => _fireResistance = value;
        }
        public float EarthResistance
        {
            get => _earthResistance;
            set => _earthResistance = value;
        }
        public float WaterResistance
        {
            get => _waterResistance;
            set => _waterResistance = value;
        }
        public float AirResistance
        {
            get => _airResistance;
            set => _airResistance = value;
        }
        public int DamageToBase
        {
            get => _damageToBase;
            set => _damageToBase = value;
        }

        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private int _currentHP;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private int _damageToBase;

        [Header("Указываются проценты")]
        [Range(0f, 100f)]
        [SerializeField]
        private float _armor;
        [Range(0f, 100f)]
        [SerializeField]
        private float _fireResistance;
        [Range(0f, 100f)]
        [SerializeField]
        private float _earthResistance;
        [Range(0f, 100f)]
        [SerializeField]
        private float _waterResistance;
        [Range(0f, 100f)]
        [SerializeField]
        private float _airResistance;

    }
}
