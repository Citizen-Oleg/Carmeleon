using System;
using TMPro;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class ViewTowerInformation : MonoBehaviour
    {
        private const string GLOBAL_ATTACK = "Глобальный";
        
        [SerializeField]
        private TextMeshProUGUI _textAttackSpeed;
        [SerializeField]
        private TextMeshProUGUI _textDamageType;
        [SerializeField]
        private TextMeshProUGUI _textDamage;
        [SerializeField]
        private TextMeshProUGUI _textRadius;
        [SerializeField]
        private Image _imageCraft;

        [Header("Buff info")]
        [SerializeField]
        private ViewBuffInfo _viewDebuffInfoEnemy;
        [SerializeField]
        private ViewBuffInfo _viewBuffInfoTower;

        public void Initialize(BestiaryItemTower bestiaryItemTower)
        {
            gameObject.SetActive(true);
            _viewBuffInfoTower.gameObject.SetActive(false);
            _viewDebuffInfoEnemy.gameObject.SetActive(false);
            
            if (bestiaryItemTower.SpriteCraftItem != null)
            {
                _imageCraft.sprite = bestiaryItemTower.SpriteCraftItem;
            }
            else
            {
                _imageCraft.gameObject.SetActive(false);
            }
            
            SetCharacteristics(bestiaryItemTower);
            ShowViewDebuffEnemy(bestiaryItemTower);
            ShowViewBuffTower(bestiaryItemTower);
        }

        private void SetCharacteristics(BestiaryItemTower bestiaryItemTower)
        {
            var characteristics = bestiaryItemTower.Item.Tower.TowerCharacteristics;
            _textAttackSpeed.text = characteristics.AttackSpeed.ToString();
            _textDamageType.text = GetTextDamageType(characteristics.DamageType);
            _textDamage.text = characteristics.Damage.ToString();
            _textRadius.text = characteristics.AttackRadius == 0 ? GLOBAL_ATTACK : characteristics.AttackRadius.ToString();
        }

        private void ShowViewDebuffEnemy(BestiaryItemTower bestiaryItemTower)
        {
            if (bestiaryItemTower.SettingsDebuffEnemy != null)
            {
                var buff = bestiaryItemTower.SettingsDebuffEnemy;
                _viewDebuffInfoEnemy.Initialize(buff.Sprite, buff.Name, buff.Description);
            }
        }

        private void ShowViewBuffTower(BestiaryItemTower bestiaryItemTower)
        {
            if (bestiaryItemTower.SettingsBuffTower != null)
            {
                var buff = bestiaryItemTower.SettingsBuffTower;
                _viewBuffInfoTower.Initialize(buff.Sprite, buff.Name, buff.Description);
            }
        }
        
        private string GetTextDamageType(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Air:
                    return "Воздух";
                case  DamageType.Clean:
                    return "Чистый";
                case DamageType.Earth:
                    return "Земля";
                case DamageType.Fire:
                    return "Огненный";
                case DamageType.Physical:
                    return "Физический";
                case DamageType.Water:
                    return "Вода";
                default:
                    return "Неизвестно";
            }
        }
    }
}