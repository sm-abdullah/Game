using Entites;
using System;
using System.Windows.Forms;

namespace Game.Business
{
    public class MotionDriver : IMotionDriver
    {
        private Timer _timer;
        private int _speed = 6;
        private IImageBoxControl _control;
        private ImageDirection _direction;
        private const int _delta = 2;
        public event ImageReached ImageReached;
        public MotionDriver()
        {
            _timer = new Timer();
            _timer.Interval = _speed;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_direction == ImageDirection.TopBottom)
            {
                if (this._control.Parent.Height > this._control.Top + this._control.Height)
                {
                    this._control.Top += _delta;
                }
              
            }
            else if (_direction == ImageDirection.LeftTop)
            {
                this._control.Top -= _delta;
                this._control.Left -= _delta;


            }
            else if (_direction == ImageDirection.LeftBottom)
            {
                this._control.Top += _delta;
                this._control.Left -= _delta;

            }
            else if (_direction == ImageDirection.RightBottom)
            {
                this._control.Top += _delta;
                this._control.Left += _delta;
            }
            else if (_direction == ImageDirection.RightTop)
            {
                this._control.Top -= _delta;
                this._control.Left += _delta;
            }

            if (this._control.Top < 1 || this._control.Left < 1
                || (this._control.Top + this._control.Height >= this._control.Parent.Height)
                || (this._control.Width + this._control.Left >= this._control.Parent.Width))
            {
                this._timer.Stop();
                ImageReached?.Invoke(_control, _direction);
            }

        }

        public void PlayAnimation(ImageDirection direction, IImageBoxControl control)
        {
            this._control = control;
            this._direction = direction;
            _timer.Start();

        }
        public void Pause()
        {
            _timer.Stop();
        }
         
        public void Dispose()
        {
            this._timer.Tick -= Timer_Tick;
            _timer.Dispose();
            this._control = null;
        }
    }
}
