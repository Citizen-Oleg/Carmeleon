using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerCharacteristics))]
    public class Tower : MonoBehaviour
    {
        public TowerCharacteristics TowerCharacteristics => _towerCharacteristics;
        
        [SerializeField]
        private TowerCharacteristics _towerCharacteristics;
    }
}
