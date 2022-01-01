using System;
using BuffSystem;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
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

        private void Awake()
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
