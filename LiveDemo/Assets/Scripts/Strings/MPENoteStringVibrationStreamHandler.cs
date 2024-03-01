using System;
using System.Collections.Generic;
using Sonosthesia.Channel;
using Sonosthesia.MIDI;
using Sonosthesia.Trigger;
using UniRx;
using UnityEngine;

namespace Sonosthesia
{
    public class MPENoteStringVibrationStreamHandler : StreamHandler<MPENote>
    {
        [SerializeField] private Transform _pos1;
        public Transform Pos1
        {
            get => _pos1;
            set => _pos1 = value;
        }
        
        [SerializeField] private Transform _pos2;
        public Transform Pos2
        {
            get => _pos2;
            set => _pos2 = value;
        }

        [SerializeField] private MPENoteSelector _valueSelector;
        
        [SerializeField] private MPENoteSelector _timeSelector;

        [SerializeField] private List<Triggerable> _triggerables;
        
        protected override IDisposable InternalHandleStream(IObservable<MPENote> stream)
        {
            return Disposable.Empty;
        }
    }    
}

