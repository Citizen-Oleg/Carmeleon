using System;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerCharacteristics))]
    [RequireComponent(typeof(IAttackBehaviour))]
    public class Tower : MonoBehaviour
    {
        public TowerCharacteristics TowerCharacteristics => _towerCharacteristics;
        public IAttackBehaviour AttackBehavior => _attackBehavior;
        
        [SerializeField]
        private TowerCharacteristics _towerCharacteristics;
       
        private IAttackBehaviour _attackBehavior;

        private void Awake()
        {
            _attackBehavior = GetComponent<IAttackBehaviour>();
        }
    }
}
