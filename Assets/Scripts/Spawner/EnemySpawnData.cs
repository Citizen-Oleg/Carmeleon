using System;
using Enemy;
using NodeMovement;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс хранит в себе данные необходимые при спавне.
    /// </summary>
    [Serializable]
    public class EnemySpawnData
    {
        public Node StartNode => _startNode;
        public int Count => _count;
        public TypeEnemy TypeEnemy => _typeEnemy;

        [SerializeField]
        private TypeEnemy _typeEnemy;
        [SerializeField]
        private Node _startNode;
        [SerializeField]
        private int _count;
    }
}