using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Tower))]
    public class TowerCharacteristics : MonoBehaviour
    {
        public float AttackRadius
        {
            get => _attackRadius;
            set => _attackRadius = value;
        }
       
        public float PercentageDamageReduction
        {
            get => _percentageDamageReduction;
            set => _percentageDamageReduction = Mathf.Clamp(value, 0, 100f);
        }

        public float PercentageIncreaseDamage
        {
            get => _percentageIncreaseDamage;
            set => _percentageIncreaseDamage = Mathf.Clamp(value, 0, 100f);
        }
        public float PercentageAttackSpeedReduction
        {
            get => _percentageAttackSpeedReduction;
            set => _percentageAttackSpeedReduction = Mathf.Clamp(value, 0, 100f);
        }

        public float PercentageIncreaseAttackSpeed
        {
            get => _percentageIncreaseAttackSpeed;
            set => _percentageIncreaseAttackSpeed = Mathf.Clamp(value, 0, 100f);
        }

        public int Damage => (int) (_baseDamage * (1 + _percentageIncreaseDamage / 100f) * (1 - _percentageDamageReduction / 100f));
        public float AttackSpeed => _baseAttackSpeed * (1 + _percentageIncreaseAttackSpeed / 100f) * (1 - _percentageAttackSpeedReduction / 100f);
        public DamageType DamageType => _damageType;

        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private int _baseDamage;
        [SerializeField]
        private float _baseAttackSpeed;
        [SerializeField]
        private float _attackRadius;

        private float _percentageIncreaseAttackSpeed;
        private float _percentageAttackSpeedReduction;
        private float _percentageIncreaseDamage;
        private float _percentageDamageReduction;

    }
}