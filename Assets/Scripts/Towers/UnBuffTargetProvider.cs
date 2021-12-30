using EnemyComponent;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(IBuffBehaviour<Enemy>))]
    public class UnBuffTargetProvider : MonoBehaviour, ITargetProvider
    {
        private readonly NearestBuffTargetProvider _nearestBuffTargetProvider = new NearestBuffTargetProvider();

        private IBuffBehaviour<Enemy> _buffBehaviour;
        private Tower _tower;

        private void Awake()
        {
            _tower = GetComponent<Tower>();
            _buffBehaviour = GetComponent<IBuffBehaviour<Enemy>>();
        }

        public Enemy GetTarget()
        {
            return _nearestBuffTargetProvider.GetNearestNoBuffTarget(LevelManager.EnemyManager.Enemies, _tower.transform.position, 
                _buffBehaviour.SettingsBuff, _tower.TowerCharacteristics.AttackRadius);
        }
    }
}