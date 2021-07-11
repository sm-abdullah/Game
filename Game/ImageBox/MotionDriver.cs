using System;
using System.Windows.Forms;

namespace Game.ImageBox
{
    public class MotionDriver : IMotionDriver
    {
        private Timer timer;
        private int speed = 6;
        private IImageBoxControl control;
        private ImageDirection direction;
        private const int delta = 2;
        public event ImageReached ImageReached;
        public MotionDriver()
        {
            timer = new Timer();
            timer.Interval = speed;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (direction == ImageDirection.TopBottom)
            {
                if (this.control.Parent.Height > this.control.Top + this.control.Height)
                {
                    this.control.Top += delta;
                }
              
            }
            else if (direction == ImageDirection.LeftTop)
            {
                this.control.Top -= delta;
                this.control.Left -= delta;


            }
            else if (direction == ImageDirection.LeftBottom)
            {
                this.control.Top += delta;
                this.control.Left -= delta;

            }
            else if (direction == ImageDirection.RightBottom)
            {
                this.control.Top += delta;
                this.control.Left += delta;
            }
            else if (direction == ImageDirection.RightTop)
            {
                this.control.Top -= delta;
                this.control.Left += delta;
            }

            if (this.control.Top < 1 || this.control.Left < 1
                || (this.control.Top + this.control.Height >= this.control.Parent.Height)
                || (this.control.Width + this.control.Left >= this.control.Parent.Width))
            {
                this.timer.Stop();
                ImageReached?.Invoke(control, direction);
            }

        }

        public void PlayAnimation(ImageDirection direction, IImageBoxControl control)
        {
            this.control = control;
            this.direction = direction;
            timer.Start();

        }
        public void Pause()
        {
            timer.Stop();
        }
         
        public void Dispose()
        {
            this.timer.Tick -= Timer_Tick;
            timer.Dispose();
            this.control = null;
        }
    }
}
