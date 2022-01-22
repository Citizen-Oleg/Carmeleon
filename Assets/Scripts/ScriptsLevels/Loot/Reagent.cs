using System;
using System.Collections;
using Interface;
using Inventory;
using ScriptsLevels.Inventory;
using ScriptsLevels.Level;
using UnityEngine;

namespace Loot
{
    [RequireComponent(typeof(Animator))]
    public class Reagent : MonoBehaviour, IDropItem, IExplanationObject
    {
        public int ID => _id;
        public string Name => _name;
        public Transform Position => _positionExplanationUI;
        
        [SerializeField]
        private int _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Transform _positionExplanationUI;
        [SerializeField]
        private float _timeDisappearance;
        [SerializeField]
        private InventoryItem _item;

        [Header("Animation data")]
        [Range(10f, 70f)]
        [SerializeField]
        private float _fadeAnimationPercentage;

        private float _fadeStartTime;
        
        private ReagentAnimationController _reagentAnimationController;
        private ReagentPool _reagentPool;
        private InventoryManager _inventoryManager;
        
        private void Awake()
        {
            _reagentAnimationController = new ReagentAnimationController(GetComponent<Animator>());
            _inventoryManager = LevelManager.InventoryManager;
            _reagentPool = LevelManager.ReagentPool;

            _fadeStartTime = _timeDisappearance * (_fadeAnimationPercentage / 100f);
        }

        private void OnEnable()
        {
            StartCoroutine(DisappearanceCountdown());
        }

        private IEnumerator DisappearanceCountdown()
        {
            var time = Time.time + _timeDisappearance;
            var duration = _timeDisappearance;
            
            
            while (time > Time.time)
            {
                duration -= Time.deltaTime;

                if (duration < _fadeStartTime)
                {
                    _reagentAnimationController.Disappearance();
                }
                
                
                yield return null;
            }
            _reagentAnimationController.DefaultState();
            _reagentPool.ReleaseReagent(this);
        }

        public void PickUp()
        {
            if (_inventoryManager.AddItemToSlot(_item))
            {
                StopCoroutine(DisappearanceCountdown());
                _reagentAnimationController.DefaultState();
                _reagentPool.ReleaseReagent(this);
            }
        }
    }
}