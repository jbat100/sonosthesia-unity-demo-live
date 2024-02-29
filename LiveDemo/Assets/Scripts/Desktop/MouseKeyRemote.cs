using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    /// <summary>
    /// Silly test util to move an object around in 3d using the mouse with predefined plane constraints
    /// Using the old input manager
    /// </summary>
    public class MouseKeyRemote : MonoBehaviour
    {
        public enum OrientationMode
        {
            CameraForward,
            CameraFlat
        }
        
        [SerializeField] private Transform _target;

        [SerializeField] private float _scrollSensitivity = 1f;

        [SerializeField] private OrientationMode _orientationMode;

        [SerializeField] private List<float> _distances;

        [SerializeField] private KeyCode _switchDistanceKey = KeyCode.S;

        [SerializeField] private KeyCode _resetDistanceKey = KeyCode.R;

        [SerializeField] private Transform _planeIndicator;

        [SerializeField] private Transform _targetIndicator;
        
        private int _distanceIndex;
        private float _distance;

        private Camera _camera;
        private Camera Camera => _camera ? _camera : (_camera = Camera.main);

        private void ResetDistance()
        {
            if (_distances.Count > 0)
            {
                _distanceIndex %= _distances.Count;
                _distance = _distances[_distanceIndex];
            }
            else
            {
                _distance = 0f;
            }
        }
        
        private void SwitchDistance()
        {
            _distanceIndex++;
            ResetDistance();
        }
        
        protected virtual void OnEnable()
        {
            ResetDistance();
        }
        
        protected virtual void Update()
        {
            if (Input.GetKeyDown(_switchDistanceKey))
            {
                SwitchDistance();
            }
            else if (Input.GetKeyDown(_resetDistanceKey))
            {
                ResetDistance();
            }

            Vector3 direction = _orientationMode switch
            {
                OrientationMode.CameraForward => Camera.transform.forward,
                OrientationMode.CameraFlat => Vector3.ProjectOnPlane(Camera.transform.forward, Vector3.up).normalized,
                _ => Vector3.forward
            };
            
            Vector3 origin = transform.position + _distance * direction;

            _planeIndicator.position = origin;
            _planeIndicator.rotation = Quaternion.LookRotation(direction, Vector3.up);

            if (!Input.GetMouseButton(0))
            {
                _targetIndicator.gameObject.SetActive(false);
                return;
            }

            if (Input.mouseScrollDelta != Vector2.zero)
            {
                _distance += Input.mouseScrollDelta.y * _scrollSensitivity;
            }

            Plane plane = new Plane(-direction, origin);
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out float enter))
            {
                Vector3 target = ray.GetPoint(enter);
                _target.position = target;
                _targetIndicator.gameObject.SetActive(true);
                _targetIndicator.position = target;
            }
            else
            {
                _targetIndicator.gameObject.SetActive(false);
            }
        }
    }
    
}


