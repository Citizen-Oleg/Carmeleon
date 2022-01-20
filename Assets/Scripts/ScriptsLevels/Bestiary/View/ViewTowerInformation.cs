using TMPro;
using Towers;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class ViewTowerInformation : MonoBehaviour
    {
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
        private GameObject _fon;
        [SerializeField]
        private Image _imageBuff;
        [SerializeField]
        private TextMeshProUGUI _nameBuff;
        [SerializeField]
        private TextMeshProUGUI _descriptionBuff;
        
        public void Initialize(BestiaryItemTower bestiaryItemTower)
        {
            gameObject.SetActive(true);
            var characteristics = bestiaryItemTower.Item.Tower.TowerCharacteristics;
            
            _textAttackSpeed.text = characteristics.AttackSpeed.ToString();
            _textDamageType.text = GetTextDamageType(characteristics.DamageType);
            _textDamage.text = characteristics.Damage.ToString();
            _textRadius.text = characteristics.AttackRadius == 0 ? "Глобальный" : characteristics.AttackRadius.ToString();
            _imageCraft.sprite = bestiaryItemTower.SpriteCraftItem;
            
            var isBuff = bestiaryItemTower.SettingsBuff != null;
            _fon.gameObject.SetActive(isBuff);
            
            if (isBuff)
            {
                _imageBuff.sprite = bestiaryItemTower.SettingsBuff.Sprite;
                _nameBuff.text = bestiaryItemTower.SettingsBuff.Name;
                _descriptionBuff.text = bestiaryItemTower.SettingsBuff.Description;
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