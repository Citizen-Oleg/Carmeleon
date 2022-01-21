using System.Collections;
using PlaceInstallation;
using TMPro;
using UnityEngine;

namespace ScriptsLevels.ManagerPlaceInstallationView
{
    public class ViewPlaceInstallation : MonoBehaviour
    {
        public RectTransform RectTransform => _rectTransform;
        
        [SerializeField]
        private TextMeshProUGUI _timer;
        
        private PlaceInstallationTower _placeInstallationTower;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
        }

        public void Initialize(PlaceInstallationTower placeInstallationTower)
        {
            _placeInstallationTower = placeInstallationTower;
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            StartCoroutine(TemporaryDisplay());
        }

        private IEnumerator TemporaryDisplay()
        {
            var duration = _placeInstallationTower.BehaviorPlaceInstallation.BlockDuration;;
            var durationTime = Time.time + duration;
            
            while (durationTime > Time.time)
            {
                duration -= Time.deltaTime;
                _timer.text = duration.ToString("F1");

                yield return null;
            }

            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
