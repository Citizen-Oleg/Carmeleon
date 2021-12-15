using System;
using Factory;
using ManagerHB;
using UnityEngine;

namespace EnemyComponent
{
    [RequireComponent(typeof(MovementEnemyController))]
    [RequireComponent(typeof(CharacteristicsEnemy))]
    [RequireComponent(typeof(AttackBehaviour))]
    [RequireComponent(typeof(HealthBehavior))]
    public class Enemy : Product
    {
        public Vector2 OffSetPositionHealthBar
        {
            get => _offSetPositionHealthBar;
            set => _offSetPositionHealthBar = value;
        }
        
        public CharacteristicsEnemy CharacteristicsEnemy => _characteristicsEnemy;
        public MovementEnemyController MovementEnemyController => _movementEnemyController;
        public AttackBehaviour AttackBehaviour => _attackBehaviour;
        public HealthBehavior HealthBehavior => _healthBehavior;
        public override Enum Type => _typeEnemy;

        [SerializeField]
        private Vector2 _offSetPositionHealthBar;
        [SerializeField]
        private TypeEnemy _typeEnemy;
        [SerializeField]
        private CharacteristicsEnemy _characteristicsEnemy;
        [SerializeField]
        private MovementEnemyController _movementEnemyController;
        [SerializeField]
        private AttackBehaviour _attackBehaviour;
        [SerializeField]
        private HealthBehavior _healthBehavior;
    }
}