
using Game.ImageBox.Animation;
using System;
using System.Drawing;
namespace Game.ImageBox
{
    /// <summary>
    /// Interface that will be used to animate image like fading out effect
    /// </summary>
    public interface IImageAnimation : IDisposable
    {
        void Start(IImageBoxControl box);
        void Stop();
    }
}
