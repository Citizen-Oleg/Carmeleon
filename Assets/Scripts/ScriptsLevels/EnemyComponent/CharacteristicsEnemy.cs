using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemyComponent
{
    /// <summary>
    /// Класс хранящий в себе данные о характеристиках врага
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class CharacteristicsEnemy : MonoBehaviour
    {
        private const float MAXIMUM_HEALTH_INCREASE = 200f;
        private const float MAXIMUM_ACCELERATION_PERCENTAGE = 200f;
        private const float MAXIMUM_DECELERATION = 80f;
        
        public int BaseMaxHp
        {
            get => _maxHP;
            set => _maxHP = value;
        }
        public float PercentageIncreaseMaxHp
        {
            get => _percentageIncreaseMaxHp;
            set => _percentageIncreaseMaxHp = Mathf.Clamp(value, 0, MAXIMUM_HEALTH_INCREASE);
        }
        public int CurrentHp
        {
            get => _currentHP;
            set => _currentHP = Mathf.Clamp(value, 0 , MaxHp);
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

        public bool IsMoving
        {
            get => _isMoving && !_isFrozen;
            set
            {
                _enemy.EnemyAnimationController.SetAnimationStan(!value);
                _isMoving = value;   
            }
        }

        public float BaseSpeed
        {
            get => _baseSpeed;
            set => _baseSpeed = value;
        }

        public float PercentageSpeedReduction
        {
            get => _percentageSpeedReduction;
            set => _percentageSpeedReduction = Mathf.Clamp(value, 0, MAXIMUM_DECELERATION);
        }

        public float PercentageIncreaseSpeed
        {
            get => _percentageIncreaseSpeed;
            set => _percentageIncreaseSpeed = Mathf.Clamp(value, 0, MAXIMUM_ACCELERATION_PERCENTAGE);
        }

        public bool HasImmunityPhysical
        {
            get => _hasImmunityPhysical;
            set => _hasImmunityPhysical = value;
        }

        public bool HasImmunityWater
        {
            get => _hasImmunityWater;
            set => _hasImmunityWater = value;
        }

        public bool HasImmunityEarth
        {
            get => _hasImmunityEarth;
            set => _hasImmunityEarth = value;
        }

        public bool HasImmunityFire
        {
            get => _hasImmunityFire;
            set => _hasImmunityFire = value;
        }

        public bool HasImmunityAir
        {
            get => _hasImmunityAir;
            set => _hasImmunityAir = value;
        }

        public bool IsFrozen
        {
            get => _isFrozen;
            set => _isFrozen = value;
        }

        public float Speed => _baseSpeed * (1 + PercentageIncreaseSpeed / 100f) * (1 - PercentageSpeedReduction / 100f);
        public int MaxHp => (int) (_maxHP * (1 + PercentageIncreaseMaxHp / 100f));
        
        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private int _currentHP;
        [SerializeField]
        private float _baseSpeed;
        [SerializeField]
        private int _damageToBase;
        [SerializeField]
        private bool _isDeath;
        [SerializeField]
        private bool _isMoving = true;
        [SerializeField]
        private bool _isFrozen;
        [SerializeField]
        private bool _hasImmunityPhysical;
        [SerializeField]
        private bool _hasImmunityWater;
        [SerializeField]
        private bool _hasImmunityEarth;
        [SerializeField]
        private bool _hasImmunityFire;
        [SerializeField]
        private bool _hasImmunityAir;


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

        private float _percentageIncreaseMaxHp;
        private float _percentageIncreaseSpeed;
        private float _percentageSpeedReduction;

        private Enemy _enemy;
        
        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }
    }
}
