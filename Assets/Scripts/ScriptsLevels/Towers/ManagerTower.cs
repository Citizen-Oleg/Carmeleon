using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class ManagerTower : MonoBehaviour
    {
        public List<Tower> Towers => _towers;

        private readonly List<Tower> _towers = new List<Tower>();

        public void AddTower(Tower tower)
        {
            _towers.Add(tower);
        }

        public void RemoveTower(Tower tower)
        {
            _towers.Remove(tower);
        }
    }
}