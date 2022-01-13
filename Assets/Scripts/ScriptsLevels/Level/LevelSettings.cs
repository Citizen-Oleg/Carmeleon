using System;
using System.Collections.Generic;
using System.Linq;
using PlaceInstallation;
using UnityEngine;

namespace ScriptsLevels.Level
{
    public class LevelSettings : MonoBehaviour
    {
        public float PercentageIncreaseHealth { get; set; }
        public float EnemySpeedIncreasePercentage { get; set; }

        public List<PlaceInstallationTower> DestructionSiteInstallationTower => _destructionSiteInstallationTower;

        [SerializeField]
        private List<PlaceInstallationTower> _destructionSiteInstallationTower = new List<PlaceInstallationTower>();

        private void Awake()
        {
            var modifiers = GameManager.instance.CurrentLevel.LevelData.Modifiers;

            foreach (var modifier in modifiers.Where(modifier => modifier.IsActive))
            { 
                modifier.GetModificator().Activate();
            }
        }
    }
}