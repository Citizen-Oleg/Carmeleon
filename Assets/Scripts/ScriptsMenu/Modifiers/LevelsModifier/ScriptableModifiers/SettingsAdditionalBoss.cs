using EnemyComponent;
using Level.ScriptsMenu.Interface;
using ScriptsLevels.Level;
using ScriptsMenu.Modifiers.LevelsModifier.Modifiers;
using UnityEngine;

namespace ScriptsMenu.Modifiers.LevelsModifier.ScriptableModifiers
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ModifierSettings/AdditionalBoss", order = 0)]
    public class SettingsAdditionalBoss : Modifier
    {
        [SerializeField]
        private float _delayedSpawnEnemies = 1;
        [SerializeField]
        private Enemy _enemyPrefab;
        [SerializeField]
        private int count = 1;
        
        public override IModifier GetModificator()
        {
            var spawner = LevelManager.SpawnerEnemy;

            return new AdditionalBossModifier(spawner, _enemyPrefab, count, _delayedSpawnEnemies);
        }
    }
}