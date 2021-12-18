using System;
using EnemyComponent;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerHB
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _healthBarSlider;
        [SerializeField]
        private TextMeshProUGUI _health;
        
        private int _lastHp = Int32.MinValue;
        private int _lastMaxHp;
        private RectTransform _transform;
        private RectTransform _parent;

        private Vector2 _offSet;
        private CharacteristicsEnemy _characteristicsEnemy;
        
        private void Awake()
        {
            _healthBarSlider.interactable = false;
            _transform = transform as RectTransform;
            _parent = _transform.parent as RectTransform;
        }

        public void Initialize(Enemy enemy)
        {
            _characteristicsEnemy = enemy.CharacteristicsEnemy;
            _offSet = enemy.OffSetPositionHealthBar;
            _lastMaxHp = _characteristicsEnemy.MaxHp;
            
            Update();
        }

        private void Update()
        {
            _transform.anchoredPosition = UIUtility.WorldToCanvasPosition(_parent, _characteristicsEnemy.transform);
            _transform.anchoredPosition += _offSet;
            if (_characteristicsEnemy != null && (_lastHp != _characteristicsEnemy.CurrentHp 
                                                  || _lastMaxHp != _characteristicsEnemy.MaxHp))
            {
                _health.text = $"{_characteristicsEnemy.CurrentHp} / " +
                               $"{_characteristicsEnemy.MaxHp}";
                
                _healthBarSlider.value = (float) _characteristicsEnemy.CurrentHp / _characteristicsEnemy.MaxHp;

                _lastHp = _characteristicsEnemy.CurrentHp;
            }
        }
    }
}
