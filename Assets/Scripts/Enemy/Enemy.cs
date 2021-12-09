using System;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(MovementEnemyController))]
    public class Enemy : MonoBehaviour
    {
        public MovementEnemyController MovementEnemyController { get; private set; }

        private void Awake()
        {
            MovementEnemyController = GetComponent<MovementEnemyController>();
        }
    }
}