using Sonosthesia.VFX;
using UnityEngine;
using UnityEngine.VFX;

namespace Sonosthesia
{
    public class SphereHitTest : VFXEventTest
    {
        [SerializeField] private float _intensity;

        private static readonly int _intensityID = Shader.PropertyToID("intensity");
        
        protected override void ConfigureEventAttribute(VFXEventAttribute eventAttribute)
        {
            //eventAttribute.SetFloat(_intensityID, _intensity);
            eventAttribute.SetFloat("intensity", _intensity);
        }
    }
}


