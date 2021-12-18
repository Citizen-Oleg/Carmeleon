using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Tower))]
    public class TowerCharacteristics : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AttackRadius);
        }
        
        public float AttackSpeed
        {
            get => _attackSpeed;
            set => _attackSpeed = value;
        }
        public float AttackRadius
        {
            get => _attackRadius;
            set => _attackRadius = value;
        }
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        
        public DamageType DamageType => _damageType;

        [SerializeField]
        private DamageType _damageType;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _attackSpeed;
        [SerializeField]
        private float _attackRadius;
    }
}