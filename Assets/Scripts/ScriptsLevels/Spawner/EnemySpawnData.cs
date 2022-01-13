using System;
using EnemyComponent;
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
        public Node StartNode
        {
            get => _startNode;
            set => _startNode = value;
        }

        public Enemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        [SerializeField]
        private Enemy _enemy;
        [SerializeField]
        private Node _startNode;
        [SerializeField]
        private int _count;
    }
}