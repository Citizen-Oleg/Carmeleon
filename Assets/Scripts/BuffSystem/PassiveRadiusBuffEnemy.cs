using BuffSystem.SettingsBuff;
using EnemyComponent;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class PassiveRadiusBuffEnemy : MonoBehaviour
    {
        [SerializeField]
        private SettingsBuff<Enemy> _settingsBuff;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.EnemyBuffController.AddBuff(_settingsBuff);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.EnemyBuffController.StopBuff(_settingsBuff);
            }
        }
    }
}