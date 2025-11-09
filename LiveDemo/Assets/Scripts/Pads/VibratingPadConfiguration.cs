using System;
using Sonosthesia.Extractor;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    public interface IVibratingPadConfiguration<in TEvent> where TEvent : struct
    {
        IStaticExtractor<TEvent, float> Time { get; }
        IStaticExtractor<TEvent, float> Amplitude { get; }
        IStaticExtractor<TEvent, float> Offset { get; }
        IStaticExtractor<TEvent, float> Intensity { get; }
        IStaticExtractor<TEvent, float> Falloff { get; }
    }

    [Serializable]
    public class VibratingPadConfiguration<TEvent, TExtractor> : ScriptableObject, IVibratingPadConfiguration<TEvent>
        where TEvent : struct where TExtractor : IStaticExtractor<TEvent, float>
    {
        [SerializeField] private TExtractor _time;
        public IStaticExtractor<TEvent, float> Time => _time;
        
        [SerializeField] private TExtractor _amplitude;
        public IStaticExtractor<TEvent, float> Amplitude => _amplitude;

        [SerializeField] private TExtractor _offset;
        public IStaticExtractor<TEvent, float> Offset => _offset;
        
        [SerializeField] private TExtractor _intensity;
        public IStaticExtractor<TEvent, float> Intensity => _intensity;
        
        [SerializeField] private TExtractor _falloff;
        public IStaticExtractor<TEvent, float> Falloff => _falloff;
    }
}