using System;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Класс хранит в себе врага, его начальный путь и кол-во спавна врага.
    /// </summary>
    [Serializable]
    public class EnemySpawnData
    {
        public Node.Node StartNode => _startNode;
        public int Count => _count;
        public Enemy.Enemy Enemy => _enemy;

        [SerializeField]
        private Node.Node _startNode;
        [SerializeField]
        private int _count;
        [SerializeField]
        private Enemy.Enemy _enemy;
    }
}