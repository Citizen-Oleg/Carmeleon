using System;
using System.ComponentModel;
using Factory;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(MovementEnemyController))]
    [RequireComponent(typeof(CharacteristicsEnemy))]
    [RequireComponent(typeof(AttackBehaviour))]
    public class Enemy : Product
    {
        public CharacteristicsEnemy CharacteristicsEnemy => _characteristicsEnemy;
        public MovementEnemyController MovementEnemyController => _movementEnemyController;
        public AttackBehaviour AttackBehaviour => _attackBehaviour;
        public TypeEnemy TypeEnemy => _typeEnemy;
        
        [SerializeField]
        private TypeEnemy _typeEnemy;
        [SerializeField]
        private CharacteristicsEnemy _characteristicsEnemy;
        [SerializeField]
        private MovementEnemyController _movementEnemyController;
        [SerializeField]
        private AttackBehaviour _attackBehaviour;
    }
}