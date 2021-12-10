using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс отвечающий за передвижение врага по установленному пути.
    /// </summary>
    public class MovementEnemyController : MonoBehaviour
    {
        [SerializeField]
        private float _distancePointChange = 0.1f;
        
        private CharacteristicsEnemy _characteristicsEnemy;
        private Node.Node _currentNode;

        private void Update()
        {
            if (_currentNode != null)
            {
                MoveToThePoint();
            }
        }

        public void Initialize(Enemy enemy, Node.Node node)
        {
            _characteristicsEnemy = enemy.CharacteristicsEnemy;
            _currentNode = node;
        }

        private void MoveToThePoint()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentNode.transform.position,
                _characteristicsEnemy.Speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _currentNode.transform.position) <= _distancePointChange)
            {
                SetMovementToPoint();
            }
        }

        private void SetMovementToPoint()
        {
            _currentNode = _currentNode.GetNextNode();
        }
    }
}
