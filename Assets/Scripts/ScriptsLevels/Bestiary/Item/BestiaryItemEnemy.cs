using ScriptsLevels.Inventory;
using UnityEngine;

namespace ScriptsLevels.Bestiary
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BestiaryItem/Enemy", order = 2)]
    public class BestiaryItemEnemy : BestiaryItem<EnemyItem>
    {
    }
}