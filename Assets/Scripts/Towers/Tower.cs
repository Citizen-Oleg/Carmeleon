using BuffSystem;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerBuffController))]
    [RequireComponent(typeof(TowerCharacteristics))]
    public class Tower : MonoBehaviour
    {
        public TowerCharacteristics TowerCharacteristics => _towerCharacteristics;
        public TowerBuffController TowerBuffController => _towerBuffController;

        [SerializeField]
        private TowerCharacteristics _towerCharacteristics;
        [SerializeField]
        private TowerBuffController _towerBuffController;
    }
}
