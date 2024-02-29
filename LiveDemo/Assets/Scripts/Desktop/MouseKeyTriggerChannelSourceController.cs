using Sonosthesia.Touch;
using UnityEngine;

namespace Sonosthesia
{
    public class MouseKeyTriggerChannelSourceController : MonoBehaviour
    {
        [SerializeField] private BaseTriggerSource _source;

        [SerializeField] private KeyCode _endAllKeyCode = KeyCode.E;

        protected virtual void Update()
        {
            if (Input.GetKeyDown(_endAllKeyCode))
            {
                _source.EndAllStreams();
            }
        }
    }    
}


