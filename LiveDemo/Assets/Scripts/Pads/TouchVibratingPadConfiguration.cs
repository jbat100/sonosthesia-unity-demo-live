using Sonosthesia.Touch;
using UnityEngine;

namespace Sonosthesia.LiveDemo
{
    [CreateAssetMenu(fileName = "TouchVibratingPadConfiguration", 
        menuName = "Sonosthesia/LiveDemo/TouchVibratingPadConfiguration")]
    public class TouchVibratingPadConfiguration : VibratingPadConfiguration<TouchEvent, FloatTouchStaticExtractor>
    {
        
    }
}