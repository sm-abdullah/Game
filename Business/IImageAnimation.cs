using Entites;
using System;
namespace Game.Business
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
