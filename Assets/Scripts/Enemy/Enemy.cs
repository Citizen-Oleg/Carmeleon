using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(MovementEnemyController))]
    [RequireComponent(typeof(CharacteristicsEnemy))]
    public class Enemy : MonoBehaviour
    {
        public CharacteristicsEnemy CharacteristicsEnemy { get; private set; }
        public MovementEnemyController MovementEnemyController { get; private set; }

        private void Awake()
        {
            CharacteristicsEnemy = GetComponent<CharacteristicsEnemy>();
            MovementEnemyController = GetComponent<MovementEnemyController>();
        }
    }
}