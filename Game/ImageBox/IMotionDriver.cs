
using System;

namespace Game.ImageBox
{
    public interface IMotionDriver : IDisposable
    {
        void PlayAnimation(ImageDirection direction, IImageBoxControl control);
        void Pause();
        event ImageReached ImageReached;

    }
}
