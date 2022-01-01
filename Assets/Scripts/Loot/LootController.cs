using EnemyComponent;
using ResourceManager;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Класс отвечающий за получение лута с убитого врага.
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class LootController : MonoBehaviour
    {
        public Resource Resource
        {
            get => _resource;
            set => _resource = value;
        }

        [SerializeField]
        private Resource _resource;

        private Enemy _enemy;
        private ResourceManagerLevel _resourceManagerLevel;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _resourceManagerLevel = LevelManager.ResourceManagerLevel;
            
            _enemy.HealthBehavior.OnDead += AwardAccrual;
        }

        private void AwardAccrual(Enemy enemy)
        {
            _resourceManagerLevel.AddResource(_resource);
        }

        private void OnDestroy()
        {
            if (_enemy != null)
            {
                _enemy.HealthBehavior.OnDead -= AwardAccrual;
            }
        }
    }
}
