using System;
using BuffSystem;
using Interface;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(TowerBuffController))]
    [RequireComponent(typeof(TowerCharacteristics))]
    public class Tower : MonoBehaviour, IExplanationObject
    {
        public string Explanation => _name;
        public Transform Position => _positionExplanationUI;
        public TowerCharacteristics TowerCharacteristics => _towerCharacteristics;
        public TowerBuffController TowerBuffController => _towerBuffController;
        
        [SerializeField]
        private string _name;
        [SerializeField]
        private Transform _positionExplanationUI;
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
