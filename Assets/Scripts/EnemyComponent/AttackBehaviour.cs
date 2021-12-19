using Event;
using Player;
using SimpleEventBus;
using UnityEngine;

namespace EnemyComponent
{
    /// <summary>
    /// Класс отвечает за нанесение урона врагом.
    /// </summary>
    [RequireComponent(typeof(Enemy))]
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
            EventStreams.UserInterface.Publish(new EnemyDestroyedEvent(_enemy));
        }

        private void OnDestroy()
        {
            if (_enemy != null)
            {
                _enemy.MovementEnemyController.OnFinishPoint -= Attack;
            }
        }
    }
}