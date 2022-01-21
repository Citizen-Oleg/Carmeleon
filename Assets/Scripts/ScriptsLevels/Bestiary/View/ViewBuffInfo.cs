using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptsLevels.Bestiary
{
    public class ViewBuffInfo : MonoBehaviour
    {
        [SerializeField]
        private Image _imageBuff;
        [SerializeField]
        private TextMeshProUGUI _nameBuff;
        [SerializeField]
        private TextMeshProUGUI _descriptionBuff;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Initialize(Sprite spriteBuff, string nameBuff, string descriptionBuff)
        {
            gameObject.SetActive(true);
            _imageBuff.sprite = spriteBuff;
            _nameBuff.text = nameBuff;
            _descriptionBuff.text = descriptionBuff;
        }
    }
}