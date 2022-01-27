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

        
        private Enemy _enemy;

        private void Awake()
        {
            _healthBarSlider.interactable = false;
            _transform = transform as RectTransform;
            _parent = _transform.parent as RectTransform;
        }

        private void Update()
        {
            _transform.anchoredPosition = UIUtility.WorldToCanvasPosition(_parent, _enemy.PositionHealthBar);
        }

        private void OnDestroy()
        {
            if (_enemy != null)
            {
                _enemy.HealthBehavior.OnHealthСhanges -= RefreshUI;
            }
        }

        public void Initialize(Enemy enemy)
        {
            _enemy = enemy;
            _lastMaxHp = _enemy.CharacteristicsEnemy.MaxHp;
            
            Update();
            RefreshUI();

            _enemy.HealthBehavior.OnHealthСhanges += RefreshUI;
        }

        private void RefreshUI()
        {
            var characteristicsEnemy = _enemy.CharacteristicsEnemy;
            if (characteristicsEnemy != null && (_lastHp != characteristicsEnemy.CurrentHp 
                                                  || _lastMaxHp != characteristicsEnemy.MaxHp))
            {
                _health.text = $"{characteristicsEnemy.CurrentHp} / " +
                               $"{characteristicsEnemy.MaxHp}";
                
                _healthBarSlider.value = (float) characteristicsEnemy.CurrentHp / characteristicsEnemy.MaxHp;

                _lastHp = characteristicsEnemy.CurrentHp;
            }
        }
    }
}
