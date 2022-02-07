using Interface;
using Towers;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class TemporaryReducingTowerDamageBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasTimeAction => _startTime + _duration > Time.time;
        
        private readonly Tower _tower;
        private readonly float _reductionPercentage;
        private readonly float _duration;

        private float _startTime;

        public TemporaryReducingTowerDamageBuff(Tower tower, float reductionPercentage, float duration)
        {
            _tower = tower;
            _reductionPercentage = reductionPercentage;
            _duration = duration;
        }
        
        public void Start()
        {
            IsActive = true;
            _tower.TowerCharacteristics.PercentageDamageReduction += _reductionPercentage;
            _startTime = Time.time;
        }

        public void Stop()
        {
            IsActive = false;
            _tower.TowerCharacteristics.PercentageDamageReduction -= _reductionPercentage;
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