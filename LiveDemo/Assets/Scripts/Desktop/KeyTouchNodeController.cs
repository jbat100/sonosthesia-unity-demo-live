using Sonosthesia.Touch;
using UnityEngine;

namespace Sonosthesia
{
    [RequireComponent(typeof(TouchNode))]
    public class KeyTouchNodeController : MonoBehaviour
    {
        [SerializeField] private KeyCode _killKey;
        
        private TouchNode _triggerNode;

        protected virtual void Awake()
        {
            _triggerNode = GetComponent<TouchNode>();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(_killKey))
            {
                _triggerNode.KillAllStreams();
            }
        }
    }    
}

