using Towers;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class PassiveRadiusBuffTower : MonoBehaviour
    {
        [SerializeField]
        private SettingsBuff<Tower> _settingsBuff;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Tower tower))
            {
                tower.TowerBuffController.AddBuff(_settingsBuff);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Tower tower))
            {
                tower.TowerBuffController.StopBuff(_settingsBuff);
            }
        }
    }
}