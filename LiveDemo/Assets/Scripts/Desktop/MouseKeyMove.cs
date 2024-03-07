using UnityEngine;

namespace Sonosthesia
{
    public class MouseKeyMove : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private KeyCode _upKey;

        [SerializeField] private KeyCode _downKey;

        [SerializeField] private float _speed = 1f;
        
        protected virtual void Awake()
        {
            if (!_target)
            {
                _target = transform;
            }
        }

        protected virtual void Update()
        {
            Vector3 direction = Vector3.zero;
            
            if (Input.GetKey(_upKey))
            {
                direction += Vector3.up;
            }

            if (Input.GetKey(_downKey))
            {
                direction += Vector3.down;
            }

            _target.localPosition = _target.localPosition + _speed * Time.deltaTime * direction;
        }
        
        
    }    
}


