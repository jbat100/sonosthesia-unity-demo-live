using Sonosthesia.MIDI;
using Sonosthesia.Touch;
using Sonosthesia.Utils;
using UnityEngine;
using UnityEngine.VFX;

namespace Sonosthesia
{
    public class SphereHitMIDINoteTriggerVFXEventValueAffordance : TriggerVFXEventValueAffordance<MIDINote, ValueTriggerEndpoint<MIDINote>>
    {
        private static readonly int _intensityID = Shader.PropertyToID("intensity");
        
        [SerializeField] private Selector<MIDINote> _intensitySelector;

        protected override void ConfigureEventAttribute(VFXEventAttribute eventAttribute, TriggerValueEvent<MIDINote> valueEvent)
        {
            eventAttribute.SetFloat(_intensityID, _intensitySelector.Select(valueEvent.Value));
        }
    }    
}

