using System;
using Event;
using Player;
using SimpleEventBus;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс отвечает за нанесение урона врагом.
    /// </summary>
    public class AttackBehaviour : MonoBehaviour
    {
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _enemy.MovementEnemyController.OnFinishPoint += Attack;
        }

        private void OnEnable()
        {
            Start();
        }

        private void Attack(PlayerBase playerBase)
        {
            playerBase.TakeDamage(_enemy.CharacteristicsEnemy.DamageToBase);
            EventStreams.UserInterface.Publish(new EnemyDestroyedEvent(_enemy.TypeEnemy, _enemy));
        }

        private void OnDisable()
        {
            _enemy.MovementEnemyController.OnFinishPoint -= Attack;
        }
    }
}