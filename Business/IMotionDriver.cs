using Entites;
using System;

namespace Game.Business
{
    public interface IMotionDriver : IDisposable
    {
        void PlayAnimation(ImageDirection direction, IImageBoxControl control);
        void Pause();
        event ImageReached ImageReached;

    }
}
