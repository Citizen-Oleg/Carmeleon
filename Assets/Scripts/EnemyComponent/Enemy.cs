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
    public class Enemy : MonoBehaviour, IProduct<TypeEnemy>
    {
        public Vector2 OffSetPositionHealthBar
        {
            get => _offSetPositionHealthBar;
            set => _offSetPositionHealthBar = value;
        }
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }
        
        public TypeEnemy TypeEnum => _typeEnemy;
        public CharacteristicsEnemy CharacteristicsEnemy => _characteristicsEnemy;
        public MovementEnemyController MovementEnemyController => _movementEnemyController;
        public AttackBehaviour AttackBehaviour => _attackBehaviour;
        public HealthBehavior HealthBehavior => _healthBehavior;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
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