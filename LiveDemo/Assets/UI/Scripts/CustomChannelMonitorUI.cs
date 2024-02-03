using System;
using System.Collections.Generic;
using System.Linq;
using Sonosthesia.Channel;
using Sonosthesia.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sonosthesia.UI
{
    public abstract class CustomChannelMonitorUI<TData, TController> : MonoBehaviour 
        where TData : struct 
        where TController : class, ISimpleListEntryController<ChannelStreamUIData<TData>>, new()
    {
        [SerializeField] private Channel<TData> _channel;
        
        [SerializeField] private UIDocument _document;

        [SerializeField] VisualTreeAsset _listEntryTemplate;

        protected virtual float ItemHeight => 27;
        
        private int _count;
        private bool _dirty;
        private int _messageCount;
        private SimpleListController<ChannelStreamUIData<TData>, TController> _listController;

        private IDisposable _subscription;

        private List<ChannelStreamUIData<TData>> _data = new();

        protected virtual void OnValidate()
        {
            if (isActiveAndEnabled && Application.isPlaying)
            {
                ReloadSubscription();   
            }
            _dirty = true;
        }
        
        protected virtual void OnEnable()
        {
            VisualElement rootElement = _document.rootVisualElement;
            
            _listController = new SimpleListController<ChannelStreamUIData<TData>, TController>(ItemHeight);
            ListView listView = rootElement.Q<ListView>("MessageList");
            _listController.InitializeList(listView, _listEntryTemplate);
            _listController.ImportData(Enumerable.Empty<ChannelStreamUIData<TData>>());
            
            _data = new List<ChannelStreamUIData<TData>>();
            ReloadSubscription();
            _dirty = true;
        }

        protected virtual void OnDisable()
        {
            _subscription?.Dispose();
            _subscription = null;
            _data.Clear();
        }

        protected virtual void Update()
        {
            if (_dirty)
            {
                _listController.ImportData(_data ?? Enumerable.Empty<ChannelStreamUIData<TData>>());
                _dirty = false;
            }
        }

        private void ReloadSubscription()
        {
            TimeSpan referenceTime = TimeSpan.FromSeconds(Time.time);
            _count = 0;
            _subscription?.Dispose();

            _subscription = _channel.StreamObservable.Subscribe(stream =>
            {
                int localCount = _count++;
                TimeSpan start = TimeSpan.FromSeconds(Time.time) - referenceTime;

                void Clean()
                {
                    int index = _data.FindIndex(data => data.Count == localCount);
                    if (index >= 0)
                    {
                        _data.RemoveAt(index);    
                    }
                    _dirty = true;
                }

                void UpdateValue(TData value)
                {
                    ChannelStreamUIData<TData> updated = new ChannelStreamUIData<TData>(localCount, value, start);
                    int index = _data.FindIndex(data => data.Count == localCount);
                    if (index >= 0)
                    {
                        _data[index] = updated;
                    }
                    else
                    {
                        _data.Add(updated);
                    }
                    _dirty = true;
                }
                
                stream.TakeUntil(this.OnDisableAsObservable())
                    .Subscribe(UpdateValue, exception => Clean(), Clean);
            }); 

        }
    }
}