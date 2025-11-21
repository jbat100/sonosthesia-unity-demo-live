using System;
using Sonosthesia.Interaction;
using Sonosthesia.Trigger;
using Sonosthesia.Utils;
using UniRx;
using UnityEngine;
using UnityEngine.VFX;

namespace Sonosthesia.LiveDemo
{
    // For use with VibratingString VFX 
    
    public class StringVibrationAffordance<TEvent> : InteractionAffordance<TEvent> where TEvent : struct
    {
        [SerializeField] private VisualEffect _visualEffect;
        
        [SerializeField] private InterfaceReference<IStringVibrationConfiguration<TEvent>> _configuration;
     
        [SerializeField] private AccumulationMode _accumulationMode = AccumulationMode.Max;

        [SerializeField] private int _componentIndex;
        
        private TriggerController _amplitudeController;
        private TriggerController _offsetController;
        private TriggerController _intensityController;
        
        private int _amplitudeID;
        private int _offsetID;
        private int _intensityID;

        protected override void OnEnable()
        {
            _amplitudeID = Shader.PropertyToID("Amplitude" + _componentIndex);
            _offsetID = Shader.PropertyToID("Offset" + _componentIndex);
            _intensityID = Shader.PropertyToID("Intensity" + _componentIndex);
            
            _amplitudeController = new TriggerController(_accumulationMode);
            _offsetController = new TriggerController(_accumulationMode);
            _intensityController = new TriggerController(_accumulationMode);
            
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            _amplitudeController.Dispose();
            _offsetController.Dispose();
            _intensityController.Dispose();
            
            base.OnDisable();
        }

        protected virtual void Update()
        {
            _visualEffect.SetFloat(_amplitudeID, _amplitudeController.Evaluate());
            _visualEffect.SetFloat(_offsetID, _offsetController.Evaluate());
            _visualEffect.SetFloat(_intensityID, _intensityController.Evaluate());
        }
        
        private class Controller : AffordanceController<TEvent, StringVibrationAffordance<TEvent>>, IDisposable
        {
            private IInteractiveEnvelopeSession<TEvent> _amplitude;
            private IInteractiveEnvelopeSession<TEvent> _offset;
            private IInteractiveEnvelopeSession<TEvent> _intensity;
            
            public Controller(Guid eventId, StringVibrationAffordance<TEvent> affordance) : base(eventId, affordance)
            {
            }

            protected override void Setup(TEvent e)
            {
                base.Setup(e);
                IStringVibrationConfiguration<TEvent> configuration = Affordance._configuration.Value;
                _amplitude = configuration.Amplitude.StartSession(e, Affordance._amplitudeController);
                _offset = configuration.Offset.StartSession(e, Affordance._offsetController);
                _intensity = configuration.Intensity.StartSession(e, Affordance._intensityController);
            }
            
            protected override void Update(TEvent e)
            {
                base.Update(e);
                _amplitude.Update(e);
                _offset.Update(e);
                _intensity.Update(e);
            }

            protected override void Teardown(TEvent e)
            {
                base.Teardown(e);
                _amplitude.End(e, out float amplitudeRelease);
                _offset.End(e, out float offsetRelease);
                _intensity.End(e, out float intensityRelease);
                Observable.Timer(TimeSpan.FromSeconds(Mathf.Max(amplitudeRelease, offsetRelease, intensityRelease)))
                    .Subscribe(_ => Dispose());
            }

            public void Dispose()
            {
                _amplitude?.Dispose();
                _offset?.Dispose();
                _intensity?.Dispose();
            }
        }

        protected override IObserver<TEvent> MakeController(Guid id)
        {
            if (_configuration?.Value == null)
            {
                this.LogError($"{this} expected configuration");
            }
            return _configuration?.Value != null ? new Controller(id, this) : null;
        }
    }
}