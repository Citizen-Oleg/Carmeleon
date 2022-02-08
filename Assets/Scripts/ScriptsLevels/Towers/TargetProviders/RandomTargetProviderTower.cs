using Interface;
using ScriptsLevels.Level;
using Towers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptsLevels.Towers.TargetProviders
{
    public class RandomTargetProviderTower : MonoBehaviour, ITargetProvider<Tower>
    {
        private ManagerTower _managerTower;

        private void Awake()
        {
            _managerTower = LevelManager.ManagerTower;
        }

        public Tower GetTarget()
        {
            var count = _managerTower.Towers.Count; 
            return count == 0 ? null : _managerTower.Towers[GetRandomIndex(count)];
        }

        private int GetRandomIndex(int lenght)
        {
            return Random.Range(0, lenght);
        }
    }
}