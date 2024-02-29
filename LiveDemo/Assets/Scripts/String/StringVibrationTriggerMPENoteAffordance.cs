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
        [SerializeField] private Selector<MPENote> _valueSelector;
        
        [SerializeField] private Selector<MPENote> _timeSelector;

        [SerializeField] private List<Triggerable> _triggerables;

        [SerializeField] private GameObject _restString;

        [SerializeField] private GameObject _vibratingString;
        
        protected override void HandleStream(Guid id, IObservable<TriggerValueEvent<MPENote>> stream)
        {
            stream.Take(1).Subscribe(e =>
            {
                float valueScale = _valueSelector.Select(e.Value);
                float timeScale = _timeSelector.Select(e.Value);
                foreach (Triggerable triggerable in _triggerables)
                {
                    triggerable.Trigger(valueScale, timeScale);
                }
            });
        }
    }    
}


