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

        private int _distanceIndex;
        private float _distance;

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
            
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            Camera camera = Camera.main;
            
            Vector3 direction = _orientationMode switch
            {
                OrientationMode.CameraForward => camera.transform.forward,
                OrientationMode.CameraFlat => Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up).normalized,
                _ => Vector3.forward
            };
            
            if (Input.mouseScrollDelta != Vector2.zero)
            {
                _distance += Input.mouseScrollDelta.y * _scrollSensitivity;
            }
            
            //Vector3 origin = Camera.transform.position + _distance * direction;

            //Plane plane = new Plane(-direction, origin);
            
            //Debug.Log($"{this} computing ray using mouse position {Input.mousePosition}");
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            
            _target.position = ray.GetPoint(_distance);
            
            // this is not under the mouse, it's driving me insane

            //if (plane.Raycast(ray, out float enter))
            //{
            //    Vector3 target = ray.GetPoint(enter);
            //    _target.position = target;
            //}
        }
    }
    
}


