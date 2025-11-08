using Sonosthesia.Instrument;
using Sonosthesia.MIDI;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    [CreateAssetMenu(fileName = "MIDINoteStringVibrationConfiguration", 
        menuName = "Sonosthesia/LiveDemo/MIDINoteStringVibrationConfiguration")]
    public class MIDINoteStringVibrationConfiguration : 
        StringVibrationConfiguration<MIDINote, MIDINoteEnvelopeSettings>
    {
        
    }
}