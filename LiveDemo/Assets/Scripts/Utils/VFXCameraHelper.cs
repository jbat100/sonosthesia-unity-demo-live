using UnityEngine;
using UnityEngine.VFX;


namespace Sonosthesia
{
    public class VFXCameraHelper : MonoBehaviour
    {
        [SerializeField] private VisualEffect _visualEffect;

        [SerializeField] private Camera _camera;

        [SerializeField] private string _propertyName;

        private int _propertyID;
        
        protected virtual void Awake()
        {
            if (!_camera)
            {
                _camera = Camera.main;
            }

            _propertyID = Shader.PropertyToID(_propertyName);
        }

        protected virtual void OnValidate()
        {
            _propertyID = Shader.PropertyToID(_propertyName);
        }

        protected virtual void Update()
        {
            _visualEffect.SetVector3(_propertyID, _camera.transform.position);
        }
    }
}

