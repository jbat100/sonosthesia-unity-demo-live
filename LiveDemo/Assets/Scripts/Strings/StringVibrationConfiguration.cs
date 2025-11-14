using Sonosthesia.Interaction;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    public interface IStringVibrationConfiguration<in TEvent> where TEvent : struct
    {
        IInteractiveEnvelopeSettings<TEvent> Amplitude { get; }
        IInteractiveEnvelopeSettings<TEvent> Offset { get; }
        IInteractiveEnvelopeSettings<TEvent> Intensity { get; }
    }
    
    public class StringVibrationConfiguration<TEvent, TEnvelope> : ScriptableObject, IStringVibrationConfiguration<TEvent>
        where TEvent : struct where TEnvelope : IInteractiveEnvelopeSettings<TEvent>  
    {
        [SerializeField] private TEnvelope _intensity;
        public IInteractiveEnvelopeSettings<TEvent> Intensity => _intensity;
        
        [SerializeField] private TEnvelope _amplitude;
        public IInteractiveEnvelopeSettings<TEvent> Amplitude => _amplitude;

        [SerializeField] private TEnvelope _offset;
        public IInteractiveEnvelopeSettings<TEvent> Offset => _offset;
        
    }
}