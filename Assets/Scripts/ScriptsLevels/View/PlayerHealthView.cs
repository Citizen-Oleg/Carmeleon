using System;
using Player;
using TMPro;
using UnityEngine;

namespace View
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _healthText;
        [SerializeField]
        private PlayerBase _playerBase;

        private void Start()
        {
            _playerBase.OnDamage += RefreshUI;
            RefreshUI();
        }

        private void OnDestroy()
        {
            _playerBase.OnDamage -= RefreshUI;
        }

        private void RefreshUI()
        {
            _healthText.text = _playerBase.CurrentHp.ToString();
        }
    }
}
