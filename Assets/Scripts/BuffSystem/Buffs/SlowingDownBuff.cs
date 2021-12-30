using System;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class SlowingDownBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Enemy _enemy;
        private readonly float _reductionPercentage;
        
        private float _speedReductionNumber;

        public SlowingDownBuff(Enemy enemy, float reductionPercentage)
        {
            _enemy = enemy;
            _reductionPercentage = reductionPercentage;
        }

        public void Start()
        {
            IsActive = true;
            
            _speedReductionNumber = _enemy.CharacteristicsEnemy.Speed * (_reductionPercentage / 100f);
            _enemy.CharacteristicsEnemy.Speed -= _speedReductionNumber;

        }

        public void Stop()
        {
            _enemy.CharacteristicsEnemy.Speed += _speedReductionNumber;
            IsActive = false;
        }
    }
}
