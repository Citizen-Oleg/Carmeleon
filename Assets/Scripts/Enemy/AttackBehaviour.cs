using Player;
using UnityEngine;

namespace Enemy
{
    public class AttackBehaviour : MonoBehaviour
    {
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            
            _enemy.MovementEnemyController.OnFinishPoint += Attack;
        }

        private void Attack(PlayerBase playerBase)
        {
            playerBase.TakeDamage(_enemy.CharacteristicsEnemy.DamageToBase);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _enemy.MovementEnemyController.OnFinishPoint -= Attack;
        }
    }
}