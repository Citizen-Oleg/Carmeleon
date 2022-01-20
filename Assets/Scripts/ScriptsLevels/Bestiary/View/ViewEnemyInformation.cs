using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class ViewEnemyInformation : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textHP;
        [SerializeField]
        private TextMeshProUGUI _textArmor;
        [SerializeField]
        private TextMeshProUGUI _textFireResistance;
        [SerializeField]
        private TextMeshProUGUI _textWaterResistance;
        [SerializeField]
        private TextMeshProUGUI _textAirResistance;
        [SerializeField]
        private TextMeshProUGUI _textEarthResistance;
        [SerializeField]
        private TextMeshProUGUI _textDamageToBase;
        [SerializeField]
        private TextMeshProUGUI _textSpeed;

        [Header("Buff info")]
        [SerializeField]
        private GameObject _fon;
        [SerializeField]
        private Image _imageBuff;
        [SerializeField]
        private TextMeshProUGUI _nameBuff;
        [SerializeField]
        private TextMeshProUGUI _descriptionBuff;
        
        public void Initialize(BestiaryItemEnemy bestiaryItemEnemy)
        {
            gameObject.SetActive(true);
            var characteristics = bestiaryItemEnemy.Item.Enemy.CharacteristicsEnemy;

            _textHP.text = characteristics.BaseMaxHp.ToString();
            _textArmor.text = characteristics.Armor.ToString();
            _textFireResistance.text = characteristics.FireResistance.ToString();
            _textWaterResistance.text = characteristics.WaterResistance.ToString();
            _textAirResistance.text = characteristics.AirResistance.ToString();
            _textEarthResistance.text = characteristics.EarthResistance.ToString();
            _textDamageToBase.text = characteristics.DamageToBase.ToString();
            _textSpeed.text = characteristics.BaseSpeed.ToString();
            
            var isBuff = bestiaryItemEnemy.SettingsBuff != null;
            _fon.gameObject.SetActive(isBuff);
            
            if (isBuff)
            {
                _imageBuff.sprite = bestiaryItemEnemy.SettingsBuff.Sprite;
                _nameBuff.text = bestiaryItemEnemy.SettingsBuff.Name;
                _descriptionBuff.text = bestiaryItemEnemy.SettingsBuff.Description;
            }
        }
    }
}