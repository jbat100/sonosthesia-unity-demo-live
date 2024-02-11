using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sonosthesia
{
    public class XRInstrumentInteraction : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _settingsTargets;

        [SerializeField] private InputActionReference _showSettings;

        [SerializeField] private bool _active;

        protected virtual void OnEnable()
        {
            Apply();
            _showSettings.action.performed += OnShowSettings;
        }

        protected virtual void OnDisable()
        {
            _showSettings.action.performed -= OnShowSettings;
        }
        
        protected virtual void OnShowSettings(InputAction.CallbackContext obj)
        {
            Debug.Log($"{this} {nameof(OnShowSettings)}");
            _active = !_active;
            Apply();
        }

        private void Apply()
        {
            foreach (GameObject obj in _settingsTargets)
            {
                obj.SetActive(_active);
            }
        }
    }    
}


