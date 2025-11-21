using Sonosthesia.Instrument;
using Sonosthesia.Interaction;
using Sonosthesia.MIDI;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    [CreateAssetMenu(fileName = "MPENoteStringVibrationConfiguration", 
        menuName = "Sonosthesia/LiveDemo/MPENoteStringVibrationConfiguration")]
    public class MPENoteStringVibrationConfiguration : StringVibrationConfiguration<MPENote, 
        InteractiveTriggerSettings<MPENote, FloatMPENoteDynamicExtractorSettings, FloatMPENoteStaticExtractorSettings>>
    {
        
    }
}