using Level.ScriptsMenu.Interface;
using ScriptsMenu.Modifiers.LevelsModifier.Modifiers;
using Towers;
using UnityEngine;

namespace ScriptsMenu.Modifiers.LevelsModifier.ScriptableModifiers
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ModifierSettings/TowerTypeRestriction", order = 4)]
    public class SettingsTowerTypeRestriction : Modifier
    {
        [SerializeField]
        private DamageType _damageType;
        
        public override IModifier GetModificator()
        {
            var playerData = GameManager.PlayerData;
            return new TowerTypeRestrictionModifier(_damageType, playerData);
        }
    }
}