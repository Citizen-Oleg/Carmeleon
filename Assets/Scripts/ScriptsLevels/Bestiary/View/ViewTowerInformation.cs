using System;
using System.Collections.Generic;
using EnemyComponent;
using ScriptsLevels.Bestiary.View;
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
        private List<TextDamageType> _textDamageTypes = new List<TextDamageType>();
        [SerializeField]
        private List<TextAttackType> _textAttackTypes = new List<TextAttackType>();
        [Space(2)]
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
                _imageCraft.gameObject.SetActive(true);
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
            _textDamageType.text = GetTextDamageType(characteristics.DamageType) + ", " +  GetTextByTypeAttack(characteristics.AttackType);
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
            foreach (var textDamageType in _textDamageTypes)
            {
                if (textDamageType.DamageType == damageType)
                {
                    return textDamageType.NameType;
                }
            }

            return "Неизвестно";
        }

        private string GetTextByTypeAttack(AttackType typeAttack)
        {
            foreach (var textAttackType in _textAttackTypes)
            {
                if (textAttackType.TypeAttack == typeAttack)
                {
                    return textAttackType.NameType;
                }
            }

            return "Неизвестно";
        }
    }
}