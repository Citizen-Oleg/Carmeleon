using System;
using System.Collections.Generic;
using PlaceInstallation;
using Tools;
using UnityEngine;

namespace ScriptsLevels.ManagerPlaceInstallationView
{
    public class ManagerViewInstallation : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _container;
        [SerializeField]
        private Vector2 _offSetView;
        [SerializeField]
        private ViewPlaceInstallation _viewPlaceInstallationPrefab;

        [SerializeField]
        private List<PlaceInstallationTower> _placeInstallationTowers = new List<PlaceInstallationTower>();

        private readonly Dictionary<PlaceInstallationTower, ViewPlaceInstallation> _viewPlaceInstallations =
            new Dictionary<PlaceInstallationTower, ViewPlaceInstallation>();

        private void Start()
        {
            CreateView();
        }

        private void CreateView()
        {
            foreach (var placeInstallationTower in _placeInstallationTowers)
            {
                var view = Instantiate(_viewPlaceInstallationPrefab, _container);
                view.Initialize(placeInstallationTower);
                _viewPlaceInstallations.Add(placeInstallationTower, view);
                placeInstallationTower.OnDestroyTower += ShowViewPlaceInstallation;
            }
        }

        private void Update()
        {
            foreach (var viewPlaceInstallation in _viewPlaceInstallations)
            {
                viewPlaceInstallation.Value.RectTransform.anchoredPosition = GetViewPosition(viewPlaceInstallation.Key);
            }
        }

        private Vector2 GetViewPosition(PlaceInstallationTower placeInstallationTower)
        {
            return UIUtility.WorldToCanvasPosition(_container, placeInstallationTower.transform) + _offSetView;
        }

        private void ShowViewPlaceInstallation(PlaceInstallationTower placeInstallationTower)
        {
            if (_viewPlaceInstallations.TryGetValue(placeInstallationTower, out var view))
            {
                view.Show();
            }
        }

        private void OnDestroy()
        {
            foreach (var placeInstallationTower in _placeInstallationTowers)
            {
                placeInstallationTower.OnDestroyTower -= ShowViewPlaceInstallation;
            }
        }
    }
}
