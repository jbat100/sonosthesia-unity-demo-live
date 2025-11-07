using System.Collections.Generic;
using Sonosthesia.Generator;
using UnityEngine;

namespace Sonosthesia
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(PluckVibratingTrigger))]
    public class PluckVibratingTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PluckVibratingTrigger trigger = (PluckVibratingTrigger)target;
            if(GUILayout.Button("Trigger"))
            {
                trigger.Trigger();
            }
        }
    }
#endif
    
    public class PluckVibratingTrigger : MonoBehaviour
    {
        [SerializeField] private bool _resetTime;
        
        [SerializeField] private float _valueScale = 1f;
        
        [SerializeField] private float _timeScale = 1f;
        
        [SerializeField] private List<GeneratorSignal<float>> _generators;
        
        [SerializeField] private List<Trigger.Trigger> _triggers;
        
        public void Trigger()
        {
            if (_resetTime)
            {
                foreach (GeneratorSignal<float> generator in _generators)
                {
                    generator.ResetTime();
                }    
            }

            foreach (Trigger.Trigger triggerable in _triggers)
            {
                triggerable.Trigger(_valueScale, _timeScale);
            }
        }
    }    
}


