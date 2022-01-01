using BuffSystem.SettingsBuff.EnemySettings;
using EnemyComponent;
using Interface;
using UnityEngine;

namespace BuffSystem.Buffs
{
    /// <summary>
    /// Стакающийся бафф, при максимальном стаке на цель вешается бафф заморозки.
    /// </summary>
    public class FrostbiteBuff : IStackingBuff, ITemporaryBuff
    {
        public bool IsActive { get; private set; }

        private bool _hasFrostbiteAction => _startFrostbiteTime + _frostbiteDuration > Time.time;
        
        private readonly Enemy _enemy;
        private readonly float _frostbiteDuration;
        private readonly int _maxStack;
        private readonly SettingsTemporaryFreezingBuff _settingsTemporaryFreezingBuff;

        private float _startFrostbiteTime;
        private int _currentStack;

        public FrostbiteBuff(Enemy enemy, float frostbiteDuration, int maxStack, SettingsTemporaryFreezingBuff settingsTemporaryFreezingBuff)
        {
            _enemy = enemy;
            _frostbiteDuration = frostbiteDuration;
            _maxStack = maxStack;
            _settingsTemporaryFreezingBuff = settingsTemporaryFreezingBuff;
        }
        
        public void Start()
        {
            IsActive = true;
            AddStack();
        }

        public void Stop()
        {
            IsActive = false;
            _currentStack = 0;
        }

        public void AddStack()
        {
            Refresh();
            
            _currentStack++;
            
            if (_maxStack == _currentStack)
            {
                Stop();
                _enemy.EnemyBuffController.AddBuff(_settingsTemporaryFreezingBuff);
            }
        }

        public void Update()
        {
            if (!_hasFrostbiteAction)
            {
                Stop();
            }
        }

        public void Refresh()
        {
            _startFrostbiteTime = Time.time;
        }
    }
}