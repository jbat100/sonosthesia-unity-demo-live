using System.Collections.Generic;
using Sonosthesia.Utils;
using UnityEngine;

namespace Sonosthesia
{
#if UNITY_EDITOR
    
    using UnityEditor;

    [CustomEditor(typeof(PoolTest))]
    public class PoolTestEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            PoolTest test = (PoolTest)target;
            if (GUILayout.Button("Get"))
            {
                test.Get();
            }
            if (GUILayout.Button("Release"))
            {
                test.Release();
            }
            if (GUILayout.Button("Clear"))
            {
                test.Clear();
            }
        }
    }
#endif
    
    public class PoolTest : MonoBehaviour
    {
        [SerializeField] private ScriptablePool<GameObject> _pool;

        [SerializeField] private float _radius = 10f;
        
        private readonly Stack<GameObject> _instances = new ();
        
        public void Get()
        {
            GameObject instance = _pool.Pool.Get();
            instance.transform.SetParent(transform);
            instance.transform.position = Random.insideUnitSphere * _radius;
            _instances.Push(instance);
        }

        public void Release()
        {
            GameObject instance = _instances.Pop();
            if (instance)
            {
                _pool.Pool.Release(instance);
            }
        }

        public void Clear()
        {
            _pool.Pool.Clear();
        }
    }    
}


