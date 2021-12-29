using BuffSystem;
using Towers;
using UnityEngine;

namespace Interface
{
    public class BuffTowerBehaviour : MonoBehaviour, IBuffBehaviour<Tower>
    {
        [SerializeField]
        private SettingsBuff<Tower> _settingsBuffTower;
        
        public bool CanBuff(Tower target)
        {
            return target != null && target.gameObject.activeSelf;
        }

        public void BuffTarget(Tower target)
        {
            target.TowerBuffController.AddBuff(_settingsBuffTower);
        }

        public void StopBuffTarget(Tower target)
        {
            target.TowerBuffController.StopBuff(_settingsBuffTower);
        }
    }
}