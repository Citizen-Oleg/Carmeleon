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
        private ViewBuffInfo _viewBuffInfoTower;
        [SerializeField]
        private ViewBuffInfo _viewBuffInfoEnemy;
        
        public void Initialize(BestiaryItemEnemy bestiaryItemEnemy)
        {
            gameObject.SetActive(true);
            _viewBuffInfoTower.gameObject.SetActive(false);
            _viewBuffInfoEnemy.gameObject.SetActive(false);
            
            var characteristics = bestiaryItemEnemy.Item.Enemy.CharacteristicsEnemy;

            _textHP.text = characteristics.BaseMaxHp.ToString();
            _textArmor.text = characteristics.Armor.ToString();
            _textFireResistance.text = characteristics.FireResistance.ToString();
            _textWaterResistance.text = characteristics.WaterResistance.ToString();
            _textAirResistance.text = characteristics.AirResistance.ToString();
            _textEarthResistance.text = characteristics.EarthResistance.ToString();
            _textDamageToBase.text = characteristics.DamageToBase.ToString();
            _textSpeed.text = characteristics.BaseSpeed.ToString();

            if (bestiaryItemEnemy.SettingsBuffEnemy != null)
            {
                var buff = bestiaryItemEnemy.SettingsBuffEnemy;
                _viewBuffInfoEnemy.Initialize(buff.Sprite, buff.Name, buff.Description);
            }

            if (bestiaryItemEnemy.SettingsDebuffTower != null)
            {
                var buff = bestiaryItemEnemy.SettingsDebuffTower;
                _viewBuffInfoTower.Initialize(buff.Sprite, buff.Name, buff.Description);
            }
        }
    }
}