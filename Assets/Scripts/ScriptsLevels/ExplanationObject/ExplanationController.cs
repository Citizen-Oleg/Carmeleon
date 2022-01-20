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
            var raycastHit = Physics2D.Raycast(target.origin, target.direction);

            if (raycastHit.collider == null)
            {
                _viewExplanation.Close();
                return;
            }
            
            if (raycastHit.collider.TryGetComponent(out IExplanationObject explanationObject))
            {
                _currentObject = explanationObject;

                if (!_viewExplanation.IsOpen)
                {
                    _viewExplanation.Show(explanationObject.Explanation);
                } 
            }
            else
            {
                _viewExplanation.Close();
                return;
            }
            

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
