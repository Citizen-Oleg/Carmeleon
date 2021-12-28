using System;
using BuffSystem;
using Factory;
using Interface;
using Loot;
using ManagerHB;
using UnityEngine;

namespace EnemyComponent
{
    [RequireComponent(typeof(EnemyBuffController))]
    [RequireComponent(typeof(LootController))]
    [RequireComponent(typeof(MovementEnemyController))]
    [RequireComponent(typeof(CharacteristicsEnemy))]
    [RequireComponent(typeof(AttackBehaviourEnemy))]
    [RequireComponent(typeof(HealthBehavior))]
    public class Enemy : MonoBehaviour, IProduct
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

        public int ID => _id;
        public CharacteristicsEnemy CharacteristicsEnemy => _characteristicsEnemy;
        public MovementEnemyController MovementEnemyController => _movementEnemyController;
        public AttackBehaviourEnemy AttackBehaviour => _attackBehaviour;
        public HealthBehavior HealthBehavior => _healthBehavior;
        public LootController LootController => _lootController;
        public EnemyBuffController EnemyBuffController => _enemyBuffController;

        [SerializeField]
        private int _id;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Vector2 _offSetPositionHealthBar;
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
    }
}