using Sonosthesia.Interaction;
using Sonosthesia.Pointer;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    [CreateAssetMenu(fileName = "PointerStringVibrationConfiguration", 
        menuName = "Sonosthesia/LiveDemo/PointerStringVibrationConfiguration")]
    public class PointerStringVibrationConfiguration : StringVibrationConfiguration<PointerEvent, 
        InteractiveTriggerSettings<PointerEvent, FloatPointerDynamicExtractorSettings, FloatPointerStaticExtractorSettings>>
    {
        
    }
}