using System;
using System.Collections.Generic;
using Sonosthesia.MIDI;
using Sonosthesia.Touch;
using Sonosthesia.Trigger;
using Sonosthesia.Utils;
using UniRx;
using UnityEngine;

namespace Sonosthesia
{
    // Instantiator here is tricky because we want ONE instance whenever there is 
    // one OR MORE streams, another possibility is to have a rest and vibrating
    // string and switch depending on whether vibrations are ongoing

    public class StringVibrationTriggerMPENoteAffordance : TriggerValueAffordance<MPENote, TriggerSource<MPENote>>
    {
        [SerializeField] private ValueTriggerable<MPENote> _amplitude;

        [SerializeField] private ValueTriggerable<MPENote> _offset;
        
        [SerializeField] private ValueTriggerable<MPENote> _intensity;

        [SerializeField] private GameObject _restString;

        [SerializeField] private GameObject _vibratingString;

        protected virtual void Update()
        {
            bool ongoing = _amplitude.TriggerCount + _offset.TriggerCount + _intensity.TriggerCount > 0;
            _restString.SetActive(!ongoing);
            _vibratingString.SetActive(ongoing);
        }

        protected override void HandleStream(Guid id, IObservable<TriggerValueEvent<MPENote>> stream)
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


