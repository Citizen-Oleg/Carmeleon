using System;
using BuffSystem.SettingsBuff;
using Interface;
using Towers;
using UnityEngine;

namespace ScriptsLevels.BuffSystem.BuffingBehavior
{
    public class TowerBuffBehaviour : MonoBehaviour, IBuffBehaviour<Tower>
    {
        [SerializeField]
        private SettingsBuff<Tower> _settingsBuffTower;
        
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