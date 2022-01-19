using EnemyComponent;
using Inventory;
using UnityEngine;

namespace ScriptsLevels.Inventory
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyItem", order = 3)]
    public class EnemyItem : Item
    {
        public Enemy Enemy => _enemy;

        [SerializeField]
        private Enemy _enemy;
    }
}