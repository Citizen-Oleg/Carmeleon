using UnityEngine;
using UnityEngine.EventSystems;

namespace Level
{
    public class CameraMovement : MonoBehaviour 
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private float _screenPanThreshold;
        [SerializeField]
        private float _panSpeed;
        
        [Header("Limiting the movement area")]
        [SerializeField]
        private float _upperBound;
        [SerializeField]
        private float _bottomBound;
        [SerializeField]
        private float _leftBound;
        [SerializeField]
        private float _rightBound;
        
        private Vector3 _origin;
        private Vector3 _difference;
        private bool _drag;

        private void LateUpdate()
        {
            DragCamera();
            
            if (!_drag && MouseInside())
            {
                PanWithScreenCoordinates();
            }
        }

        private bool MouseInside()
        {
            var mousePos = Input.mousePosition;
            return mousePos.x >= 0 && mousePos.x < Screen.width && mousePos.y >= 0 && mousePos.y < Screen.height;
        }

        private void DragCamera()
        {
            if (Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject())
            {
                _difference = _camera.ScreenToWorldPoint(Input.mousePosition) - _camera.transform.position;

                if (_drag == false)
                {
                    _drag = true;
                    _origin = _camera.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                _drag = false;  
            }

            if (_drag)
            {
                _camera.transform.position = _origin - _difference;
                ClampTransform();
            }
        }

        private void PanWithScreenCoordinates()
        {
            var mousePosition = Input.mousePosition;
            var positionCamera = _camera.transform.position;
            var speed = _panSpeed * Time.fixedDeltaTime;

            if (mousePosition.x > Screen.width - _screenPanThreshold)
            {
                positionCamera.x += speed;
            }

            if (mousePosition.x < _screenPanThreshold)
            {
                positionCamera.x -= speed;
            }

            if (mousePosition.y > Screen.height - _screenPanThreshold)
            {
                positionCamera.y += speed;
            }

            if (mousePosition.y < _screenPanThreshold)
            {
                positionCamera.y -= speed;
            }

            _camera.transform.position = positionCamera;
            ClampTransform();
        }
        
        private void ClampTransform()
        {
            var clampX = Mathf.Clamp(transform.position.x, _leftBound, _rightBound);
            var clampY = Mathf.Clamp(transform.position.y, _bottomBound, _upperBound);
            transform.position = new Vector3(clampX, clampY, transform.position.z);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(new Vector2(_leftBound, _upperBound), new Vector2(_rightBound, _upperBound));
            Gizmos.DrawLine(new Vector2(_leftBound, _bottomBound), new Vector2(_rightBound, _bottomBound));
            Gizmos.DrawLine(new Vector2(_leftBound, _upperBound), new Vector2(_leftBound, _bottomBound));
            Gizmos.DrawLine(new Vector2(_rightBound, _upperBound), new Vector2(_rightBound, _bottomBound));
        }
#endif
    }
}