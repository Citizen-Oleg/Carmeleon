using System;
using NodeMovement;
using Player;
using UnityEngine;

namespace EnemyComponent
{
    /// <summary>
    /// Класс отвечающий за передвижение врага по установленному пути.
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class MovementEnemyController : MonoBehaviour
    {
        public event Action<PlayerBase> OnFinishPoint;
        
        private const float DISTANCE_POINT_CHANGE = 0.1f;

        private Enemy _enemy;
        private Node _currentNode;

        private void Update()
        {
            if (_currentNode != null && _enemy.CharacteristicsEnemy.IsMoving)
            {
                MoveToThePoint();
            }
        }

        public void Initialize(Enemy enemy, Node node)
        {
            _enemy = enemy;
            _currentNode = node;
        }

        private void MoveToThePoint()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentNode.transform.position,
                _enemy.CharacteristicsEnemy.Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _currentNode.transform.position) <= DISTANCE_POINT_CHANGE)
            {
                SetMovementToPoint();
            }
        }

        private void SetMovementToPoint()
        {
            var node = _currentNode.GetNextNode();
            if (node == null)
            {
                OnFinishPoint?.Invoke(_currentNode.GetComponent<PlayerBase>());
                return;
            }
            
            _currentNode = node;
        }
    }
}
