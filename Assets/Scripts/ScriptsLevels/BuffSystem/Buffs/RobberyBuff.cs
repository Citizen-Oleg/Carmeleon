using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    public class RobberyBuff : ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasActionTime => _startTime + _duration >= Time.time;
        
        private readonly Enemy _enemy;
        private readonly float _duration;
        private readonly float _increasedChance;

        private float _startTime;

        public RobberyBuff(Enemy enemy, float duration, float increasedChance)
        {
            _enemy = enemy;
            _duration = duration;
            _increasedChance = increasedChance;
            
        }
        
        public void Start()
        {
            IsActive = true;
            _enemy.LootController.ChanceReagentDrop += _increasedChance;
            
            Refresh();
        }

        public void Stop()
        {
            IsActive = false;
            _enemy.LootController.ChanceReagentDrop -= _increasedChance;
        }

        public void Update()
        {
            if (!_hasActionTime)
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