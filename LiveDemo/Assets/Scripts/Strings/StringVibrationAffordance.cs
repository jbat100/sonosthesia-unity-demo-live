using System;
using Sonosthesia.Interaction;
using Sonosthesia.Utils;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    public class StringVibrationAffordance<TEvent> : InteractionAffordance<TEvent> where TEvent : struct
    {
        [SerializeField] private InterfaceReference<IStringVibrationConfiguration<TEvent>> _configuration;
        
        [SerializeField] private Trigger.Trigger _amplitude;
        [SerializeField] private Trigger.Trigger _offset;
        [SerializeField] private Trigger.Trigger _intensity;
        
         private class Controller : AffordanceController<TEvent, StringVibrationAffordance<TEvent>>
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
                _amplitude = configuration.Amplitude.StartSession(e, Affordance._amplitude.TriggerController);
                _offset = configuration.Amplitude.StartSession(e, Affordance._offset.TriggerController);
                _intensity = configuration.Amplitude.StartSession(e, Affordance._intensity.TriggerController);
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
                _amplitude.End(e, out float _);
                _offset.End(e, out float _);
                _intensity.End(e, out float _);
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