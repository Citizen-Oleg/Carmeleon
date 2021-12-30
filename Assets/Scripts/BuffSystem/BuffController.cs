using System;
using System.Collections.Generic;
using BuffSystem.SettingsBuff;
using Interface;
using UnityEngine;

namespace BuffSystem
{
    public abstract class BuffController<T> : MonoBehaviour
    {
        public bool HasBuff(SettingsBuff<T> settingsBuff) => _passiveBuffs.ContainsKey(settingsBuff);
        public bool IsActiveBuff(SettingsBuff<T> settingsBuff) =>
            HasBuff(settingsBuff) && _passiveBuffs[settingsBuff].IsActive;

        [SerializeField]
        private T _buffObject;
        
        private readonly Dictionary<SettingsBuff<T>, IPassiveBuff> _passiveBuffs =
            new Dictionary<SettingsBuff<T>, IPassiveBuff>();
        private readonly Dictionary<SettingsBuff<T>, IStackingBuff> _stackingBuffs =
            new Dictionary<SettingsBuff<T>, IStackingBuff>();
        private readonly Dictionary<SettingsBuff<T>, ITemporaryBuff> _temporaryBuffs =
            new Dictionary<SettingsBuff<T>, ITemporaryBuff>();
        
        private void Update()
        {
            foreach (var iTemporaryBuff in _temporaryBuffs)
            {
                iTemporaryBuff.Value.Update();
            }
        }

        public void AddBuff(SettingsBuff<T> settingsBuff)
        {
            if (HasBuff(settingsBuff) && !IsActiveBuff(settingsBuff))
            {
                _passiveBuffs[settingsBuff].Start();
                return;
            }

            if (IsActiveBuff(settingsBuff))
            {
                RefreshTemporaryBuff(settingsBuff);
                AddStack(settingsBuff);
                return;
            }
            
            var buff = settingsBuff.GetBuff(_buffObject);
            if (AddBuffToCollection(settingsBuff, buff))
            {
                _passiveBuffs[settingsBuff].Start();
            }
        }

        public void StopBuff(SettingsBuff<T> settingsBuff)
        {
            if (_passiveBuffs.TryGetValue(settingsBuff, out var passiveBuff))
            {
                if (passiveBuff.IsActive)
                {
                    passiveBuff.Stop();
                }
            }
            else
            {
                var buff = settingsBuff.GetBuff(_buffObject);
                AddBuffToCollection(settingsBuff, buff);
                _passiveBuffs[settingsBuff].Stop();
            }
        }

        public void ResetBuff()
        {
            foreach (var passiveBuff in _passiveBuffs)
            {
                if (passiveBuff.Value.IsActive)
                {
                    passiveBuff.Value.Stop();
                }
            }
        }

        private bool AddBuffToCollection(SettingsBuff<T> settingsBuff, IPassiveBuff buff)
        {
            return AddPassiveBuff(settingsBuff, buff) || AddStackingBuff(settingsBuff, buff) || AddTemporaryBuff(settingsBuff, buff);
        }

        private bool AddTemporaryBuff(SettingsBuff<T> settingsBuff, IPassiveBuff buff)
        {
            if (!(buff is ITemporaryBuff iTemporaryBuff))
            {
                return false;
            }
            
            if (_temporaryBuffs.TryGetValue(settingsBuff, out var temporaryBuff))
            {
                if (temporaryBuff.IsActive)
                {
                    temporaryBuff.Refresh();
                    return false;
                }

                return true;
            }
            
            _temporaryBuffs.Add(settingsBuff, iTemporaryBuff);
            return true;
        }

        private bool AddStackingBuff(SettingsBuff<T> settingsBuff, IPassiveBuff buff)
        {
            if (!(buff is IStackingBuff iStackingBuff))
            {
                return false;
            }
            
            if (_stackingBuffs.TryGetValue(settingsBuff, out var stackingBuff))
            {
                if (stackingBuff.IsActive)
                {
                    stackingBuff.AddStack();
                    return false;
                }

                return true;
            }
            _stackingBuffs.Add(settingsBuff, iStackingBuff);
            return true;
        }

        private bool AddPassiveBuff(SettingsBuff<T> settingsBuff, IPassiveBuff buff)
        {
            if (_passiveBuffs.TryGetValue(settingsBuff, out var passiveBuff))
            {
                return !passiveBuff.IsActive;
            }
            
            _passiveBuffs.Add(settingsBuff, buff);
            return true;
        }

        private void AddStack(SettingsBuff<T> settingsBuff)
        {
            if (_stackingBuffs.TryGetValue(settingsBuff, out var stackingBuff))
            {
                stackingBuff.AddStack();
            }
        }

        private void RefreshTemporaryBuff(SettingsBuff<T> settingsBuff)
        {
            if (_temporaryBuffs.TryGetValue(settingsBuff, out var temporaryBuff))
            {
                temporaryBuff.Refresh();
            }
        }
    }
}
