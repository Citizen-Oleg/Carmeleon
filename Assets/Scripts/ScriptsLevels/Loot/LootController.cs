using System.Collections.Generic;
using EnemyComponent;
using Level;
using ResourceManager;
using ScriptsLevels.Level;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Класс отвечающий за получение лута с убитого врага.
    /// </summary>
    [RequireComponent(typeof(Enemy))]
    public class LootController : MonoBehaviour
    {
        public float ChanceReagentDrop
        {
            get => _chanceReagentDrop;
            set => _chanceReagentDrop = value;
        }

        [SerializeField]
        private Resource _resource;
        [Range(0f, 100f)]
        [SerializeField]
        private float _chanceReagentDrop;
        [SerializeField]
        private List<Reagent> _droppedReagent = new List<Reagent>();
        
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
            if (_droppedReagent.Count != 0 && HasDropChance())
            {
                DropReagent();
            }
        }

        private void DropReagent()
        {
            var reagent = LevelManager.ReagentPool.GetReagent(GetRandomReagent());
            reagent.transform.position = transform.position;
        }

        private bool HasDropChance()
        {
            var randomNumber = Random.Range(0, 100);
            return randomNumber <= _chanceReagentDrop;
        }

        private Reagent GetRandomReagent()
        {
            var randomNumber = Random.Range(0, _droppedReagent.Count);
            return _droppedReagent[randomNumber];
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
