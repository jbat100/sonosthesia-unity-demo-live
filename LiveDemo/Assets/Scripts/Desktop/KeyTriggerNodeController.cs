using Sonosthesia.Touch;
using UnityEngine;

namespace Sonosthesia
{
    [RequireComponent(typeof(TriggerNode))]
    public class KeyTriggerNodeController : MonoBehaviour
    {
        [SerializeField] private KeyCode _killKey;
        
        private TriggerNode _triggerNode;

        protected virtual void Awake()
        {
            _triggerNode = GetComponent<TriggerNode>();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(_killKey))
            {
                _triggerNode.EndAllStreams();
            }
        }
    }    
}

