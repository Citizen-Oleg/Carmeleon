using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class TemporaryBlockTowerBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }
        
        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly Tower _tower;
        private readonly float _duration;
        
        private float _startTime;

        public TemporaryBlockTowerBuff(Tower tower, float duration)
        {
            _tower = tower;
            _duration = duration;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.CanAttack = false;
            _startTime = Time.time;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.CanAttack = true;
        }

        public void Update()
        {
            if (!_hasTimeAction)
            {
                Stop();
            }
        }

        public void Refresh()
        {
            _startTime = Time.time;
        }
    }
}