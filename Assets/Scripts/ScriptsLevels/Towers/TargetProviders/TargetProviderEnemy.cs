using EnemyComponent;
using Interface;
using Level;
using ScriptsLevels.Level;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Tower))]
    public class TargetProviderEnemy : MonoBehaviour, ITargetProvider<Enemy>
    {
        private readonly NearestTargetProvider _nearestTargetProvider = new NearestTargetProvider();

        private Tower _tower;

        private void Awake()
        {
            _tower = GetComponent<Tower>();
        }

        public Enemy GetTarget()
        {
            return _nearestTargetProvider.GetNearestTarget(LevelManager.EnemyManager.Enemies, _tower.transform.position,
                _tower.TowerCharacteristics.AttackRadius);
        }
    }
}