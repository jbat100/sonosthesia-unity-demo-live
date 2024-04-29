using System;
using Sonosthesia.Touch;
using Sonosthesia.Trigger;
using UniRx;
using UnityEngine;

namespace Sonosthesia
{
    public class StringVibrationTriggerAffordance<TValue> : TriggerValueAffordance<TValue, ValueTriggerEndpoint<TValue>> where TValue : struct
    {
        [SerializeField] private ValueTriggerable<TValue> _amplitude;

        [SerializeField] private ValueTriggerable<TValue> _offset;
        
        [SerializeField] private ValueTriggerable<TValue> _intensity;

        [SerializeField] private GameObject _restString;

        [SerializeField] private GameObject _vibratingString;

        protected virtual void Update()
        {
            // note : this causes freeze issues 
            if (_restString && _vibratingString)
            {
                bool ongoing = _amplitude.TriggerCount + _offset.TriggerCount + _intensity.TriggerCount > 0;
                _restString.SetActive(!ongoing);
                _vibratingString.SetActive(ongoing);   
            }
        }

        protected override void HandleStream(Guid id, IObservable<TriggerValueEvent<TValue>> stream)
        {
            stream.Take(1).Subscribe(e =>
            {
                _amplitude.Trigger(e.Value);
                _offset.Trigger(e.Value);
                _intensity.Trigger(e.Value);
            });
        }
    }    
}


