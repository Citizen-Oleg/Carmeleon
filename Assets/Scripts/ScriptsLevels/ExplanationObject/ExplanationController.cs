using System;
using Interface;
using Tools;
using UnityEngine;
using View;

namespace ScriptsLevels.ExplanationObject
{
    public class ExplanationController : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _explanationObjectLayer;
        [SerializeField]
        private RectTransform _container;
        [SerializeField]
        private ViewExplanation _viewExplanation;

        private IExplanationObject _currentObject;

        private void Awake()
        {
            _viewExplanation = Instantiate(_viewExplanation, _container);
            _viewExplanation.Close();
        }

        private void Update()
        {
            var target = Camera.main.ScreenPointToRay(Input.mousePosition);
            var raycastHit = Physics2D.Raycast(target.origin, target.direction, 100f, _explanationObjectLayer);

            if (raycastHit.collider == null)
            {
                _viewExplanation.Close();
                return;
            }
            
            if (raycastHit.collider.TryGetComponent(out IExplanationObject explanationObject))
            {
                _currentObject = explanationObject;
                _viewExplanation.Show(explanationObject.Name);
            }
            else
            {
                _viewExplanation.Close();
            }
        }

        private void LateUpdate()
        {
            if (_currentObject != null)
            {
                RefreshPosition();
            }
        }

        private void RefreshPosition()
        {
            _viewExplanation.RectTransform.anchoredPosition =
                UIUtility.WorldToCanvasPosition(_container, _currentObject.Position);
        }
    }
}
