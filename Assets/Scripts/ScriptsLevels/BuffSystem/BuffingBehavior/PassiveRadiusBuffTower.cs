using System;
using BuffSystem.SettingsBuff;
using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem
{
    [RequireComponent(typeof(IBuffBehaviour<Tower>))]
    [RequireComponent(typeof(Collider2D))]
    public class PassiveRadiusBuffTower : MonoBehaviour
    {
        private IBuffBehaviour<Tower> _buffBehaviour;
        
        private void Awake()
        {
            _buffBehaviour = GetComponent<IBuffBehaviour<Tower>>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Tower tower))
            {
                _buffBehaviour.BuffTarget(tower);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Tower tower))
            {
                _buffBehaviour.StopBuffTarget(tower);
            }
        }
    }
}