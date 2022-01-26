using System;
using UnityEditor;
using UnityEngine;

namespace Towers
{
    public class TowerCharacteristics : MonoBehaviour
    {
        private const float MAXIMUM_ATTACK_SPEED_INCREASE = 50;
        private const float MAXIMUM_ATTACK_SPEED_REDUCTION = 100;
        private const float MAXIMUM_DAMAGE_INCREASE = 100;
        private const float MAXIMUM_DAMAGE_REDUCTION = 90;
        
        public float AttackRadius
        {
            get => _attackRadius;
            set => _attackRadius = value;
        }
        public float PercentageDamageReduction
        {
            get => _percentageDamageReduction;
            set => _percentageDamageReduction = Mathf.Clamp(value, 0, MAXIMUM_DAMAGE_REDUCTION);
        }
        public float PercentageIncreaseDamage
        {
            get => _percentageIncreaseDamage;
            set => _percentageIncreaseDamage = Mathf.Clamp(value, 0, MAXIMUM_DAMAGE_INCREASE);
        }
        public float PercentageAttackSpeedReduction
        {
            get => _percentageAttackSpeedReduction;
            set => _percentageAttackSpeedReduction = Mathf.Clamp(value, 0, MAXIMUM_ATTACK_SPEED_REDUCTION);
        }
        public float PercentageIncreaseAttackSpeed
        {
            get => _percentageIncreaseAttackSpeed;
            set => _percentageIncreaseAttackSpeed = Mathf.Clamp(value, 0, MAXIMUM_ATTACK_SPEED_INCREASE);
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

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
#endif
    }
}