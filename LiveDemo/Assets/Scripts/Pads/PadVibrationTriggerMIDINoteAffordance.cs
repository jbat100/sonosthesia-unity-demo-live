using System;
using Sonosthesia.MIDI;
using Sonosthesia.Touch;
using Sonosthesia.Utils;
using UniRx;
using UnityEngine;

namespace Sonosthesia
{
    public class PadVibrationTriggerMIDINoteAffordance : TriggerValueAffordance<MIDINote, ValueTriggerEndpoint<MIDINote>>
    {
        [SerializeField] private Selector<MIDINote> _time;
        
        [SerializeField] private Selector<MIDINote> _amplitude;

        [SerializeField] private Selector<MIDINote> _offset;
        
        [SerializeField] private Selector<MIDINote> _intensity;
        
        [SerializeField] private Selector<MIDINote> _falloff;

        [SerializeField] private VibratingPadController _controller;

        protected override void HandleStream(Guid id, IObservable<TriggerValueEvent<MIDINote>> stream)
        {
            stream.Take(1).Subscribe(e =>
            {
                VibratingPadController.Scale scale = new VibratingPadController.Scale(
                    _time ? _time.Select(e.Value) : 1f,
                    _amplitude ? _amplitude.Select(e.Value) : 1f,
                    _offset ? _offset.Select(e.Value) : 1f,
                    _intensity ? _intensity.Select(e.Value) : 1f,
                    _falloff ? _falloff.Select(e.Value) : 1f
                    );

                Vector3 center = e.TriggerData.Source.transform.position;
                
                _controller.Trigger(center, scale);
            });
        }
    }    
}


