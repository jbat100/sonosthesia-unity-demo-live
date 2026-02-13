using System;
using Sonosthesia.Interaction;
using Sonosthesia.Utils;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    public class VibratingPadAffordance<TEvent> : InteractionAffordance<TEvent> where TEvent : struct, IInteractionEvent
    {
        [SerializeField] private InterfaceReference<IVibratingPadConfiguration<TEvent>> _configuration;

        [SerializeField] private VibratingPadController _controller;

        protected override void OnStartedStream(Guid id, TEvent e)
        {
            IVibratingPadConfiguration<TEvent> configuration = _configuration.Value;
            if (configuration == null)
            {
                return;
            }

            if (configuration.Time.Extract(e, out float time) &&
                configuration.Amplitude.Extract(e, out float amplitude) &&
                configuration.Offset.Extract(e, out float offset) &&
                configuration.Intensity.Extract(e, out float intensity) &&
                configuration.Falloff.Extract(e, out float falloff))
            {
                _controller.Trigger(e.Source.Transform.position, 
                    new VibratingPadController.Scale(time, amplitude, offset, intensity, falloff));     
            }
        }
    }    
}


