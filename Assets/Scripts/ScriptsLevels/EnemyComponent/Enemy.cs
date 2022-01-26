using System;
using BuffSystem;
using Factory;
using Interface;
using Loot;
using ManagerHB;
using UnityEngine;

namespace EnemyComponent
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(EnemyBuffController))]
    [RequireComponent(typeof(LootController))]
    [RequireComponent(typeof(MovementEnemyController))]
    [RequireComponent(typeof(CharacteristicsEnemy))]
    [RequireComponent(typeof(AttackBehaviourEnemy))]
    [RequireComponent(typeof(HealthBehavior))]
    public class Enemy : MonoBehaviour, IProduct, IExplanationObject
    {
        public Transform PositionHealthBar
        {
            get => _positionHealthBar;
            set => _positionHealthBar = value;
        }
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }
        
        public string Name => _name;
        public Transform Position => _positionExplanationUI;
        public CharacteristicsEnemy CharacteristicsEnemy => _characteristicsEnemy;
        public MovementEnemyController MovementEnemyController => _movementEnemyController;
        public AttackBehaviourEnemy AttackBehaviour => _attackBehaviour;
        public HealthBehavior HealthBehavior => _healthBehavior;
        public LootController LootController => _lootController;
        public EnemyBuffController EnemyBuffController => _enemyBuffController;
        public EnemyAnimationController EnemyAnimationController => _enemyAnimationController;
        public Transform PositionBody => _positionBody != null ? _positionBody : transform;

        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Transform _positionExplanationUI;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Transform _positionBody;
        [SerializeField]
        private Transform _positionHealthBar;
        [SerializeField]
        private LootController _lootController;
        [SerializeField]
        private CharacteristicsEnemy _characteristicsEnemy;
        [SerializeField]
        private MovementEnemyController _movementEnemyController;
        [SerializeField]
        private AttackBehaviourEnemy _attackBehaviour;
        [SerializeField]
        private HealthBehavior _healthBehavior;
        [SerializeField]
        private EnemyBuffController _enemyBuffController;

        private EnemyAnimationController _enemyAnimationController;

        private void Awake()
        {
            _enemyAnimationController = new EnemyAnimationController(GetComponent<Animator>());
        }
    }
}