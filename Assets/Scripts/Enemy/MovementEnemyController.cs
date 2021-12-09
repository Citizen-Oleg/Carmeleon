using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс отвечающий за передвижение врага по установленному пути.
    /// </summary>
    public class MovementEnemyController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        //TODO: Убрать после создания спавнера
        [SerializeField]
        private Node.Node _currentNode;
        
        private void Start()
        {
            Initialize(_currentNode);
        }

        private void Update()
        {
            if (_currentNode != null)
            {
                MoveToThePoint();
            }
        }

        public void Initialize(Node.Node node)
        {
            _currentNode = node;
            SetMovementToPoint();
        }

        private void MoveToThePoint()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentNode.transform.position,
                _speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _currentNode.transform.position) <= 0.1f)
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
