using Spawner;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerEnemy SpawnerEnemy => _spawnerEnemy;

        [SerializeField]
        private SpawnerEnemy _spawnerEnemy;
    }
}