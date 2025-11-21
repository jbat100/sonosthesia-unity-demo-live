using Sonosthesia.Interaction;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    public interface IStringVibrationConfiguration<in TEvent> where TEvent : struct
    {
        IInteractiveTriggerSettings<TEvent> Amplitude { get; }
        IInteractiveTriggerSettings<TEvent> Offset { get; }
        IInteractiveTriggerSettings<TEvent> Intensity { get; }
    }
    
    public class StringVibrationConfiguration<TEvent, TTrigger> : ScriptableObject, IStringVibrationConfiguration<TEvent>
        where TEvent : struct where TTrigger : IInteractiveTriggerSettings<TEvent>  
    {
        [SerializeField] private TTrigger _intensity;
        public IInteractiveTriggerSettings<TEvent> Intensity => _intensity;
        
        [SerializeField] private TTrigger _amplitude;
        public IInteractiveTriggerSettings<TEvent> Amplitude => _amplitude;

        [SerializeField] private TTrigger _offset;
        public IInteractiveTriggerSettings<TEvent> Offset => _offset;
    }
    
}