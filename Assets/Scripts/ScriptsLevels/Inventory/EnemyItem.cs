using EnemyComponent;
using Inventory;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/EnemyItem", order = 3)]
    public class EnemyItem : Item
    {
        public override string Name => _enemy.Name;
        public Enemy Enemy => _enemy;

        [SerializeField]
        private Enemy _enemy;
    }
}