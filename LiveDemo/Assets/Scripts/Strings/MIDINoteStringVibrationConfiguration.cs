using Sonosthesia.Instrument;
using Sonosthesia.Interaction;
using Sonosthesia.MIDI;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    [CreateAssetMenu(fileName = "MIDINoteStringVibrationConfiguration", 
        menuName = "Sonosthesia/LiveDemo/MIDINoteStringVibrationConfiguration")]
    public class MIDINoteStringVibrationConfiguration : StringVibrationConfiguration<MIDINote, 
        InteractiveTriggerSettings<MIDINote, FloatMIDINoteDynamicExtractorSettings, FloatMIDINoteStaticExtractorSettings>>
    {
        
    }
}