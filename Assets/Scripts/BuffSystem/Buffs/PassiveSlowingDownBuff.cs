using System;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Пассивное уменьшение скорости врага.
    /// </summary>
    public class PassiveSlowingDownBuff : IPassiveBuff
    {
        public bool IsActive { get; private set; }

        private readonly Enemy _enemy;
        private readonly float _reductionPercentage;
        

        public PassiveSlowingDownBuff(Enemy enemy, float reductionPercentage)
        {
            _enemy = enemy;
            _reductionPercentage = reductionPercentage;
        }

        public void Start()
        {
            IsActive = true;

            _enemy.CharacteristicsEnemy.PercentageSpeedReduction += _reductionPercentage;
        }

        public void Stop()
        {
            _enemy.CharacteristicsEnemy.PercentageSpeedReduction -= _reductionPercentage;
            IsActive = false;
        }
    }
}
