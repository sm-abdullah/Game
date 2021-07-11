
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.ImageBox
{
    public delegate void ImageReached(IImageBoxControl sender, ImageDirection direction);
    public delegate void DirectionChanged(object sender, ImageDirection direction);
    public class ImageBoxControl : PictureBox, IImageBoxControl
    {
        private Point startMouseLocation = Point.Empty;
        private Point startImageLocation = Point.Empty;
        private bool isDragging = false;
        public event ImageReached ImageReached;
        private IImageAnimation ImageAnimation;
        public IMotionDriver MotionDriver;
        public event DirectionChanged Direction_Changed;

        /// <summary>
        /// Main constructor that requires Animation and modition driver
        /// </summary>
        /// <param name="motionDriver"></param>
        /// <param name="imageAnimation"></param>
        public ImageBoxControl(IMotionDriver motionDriver, IImageAnimation imageAnimation)
        {
            SetStyle(ControlStyles.Opaque, true);
            ImageAnimation = imageAnimation;
            MotionDriver = motionDriver;
            MotionDriver.ImageReached += MotionDriver_ImageReached;

        } 

        /// <summary>
        /// Motion driver check if images reaches to the border of the form then trigger this event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="direction"></param>
        private void MotionDriver_ImageReached(IImageBoxControl sender, ImageDirection direction)
        {
            ImageReached?.Invoke(sender, direction);
        }

        public void StartDropping()
        {
            MotionDriver.PlayAnimation(ImageDirection.TopBottom, this);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            startImageLocation = this.Location;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            MotionDriver.Pause();
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startMouseLocation = new Point(e.X, e.Y);
                startImageLocation = this.Location;
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var endLocation = this.Location;
            var distance = Math.Sqrt((Math.Pow(startImageLocation.X - endLocation.X, 2) + Math.Pow(startImageLocation.Y - endLocation.Y, 2)));
            // if user pan more than 20 pix then change direction
            if (distance >= 20 && endLocation.X < startImageLocation.X && endLocation.Y < startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.LeftTop);
                MotionDriver.PlayAnimation(ImageDirection.LeftTop, this);


            }
            else if (distance >= 20 && endLocation.X > startImageLocation.X && endLocation.Y < startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.RightTop);
                MotionDriver.PlayAnimation(ImageDirection.RightTop, this);
            }
            else if (distance >= 20 && endLocation.X > startImageLocation.X && endLocation.Y > startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.RightBottom);
                MotionDriver.PlayAnimation(ImageDirection.RightBottom, this);

            }
            else if (distance >= 20 && endLocation.X < startImageLocation.X && endLocation.Y > startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.LeftBottom);
                MotionDriver.PlayAnimation(ImageDirection.LeftBottom, this);
            }
            else
            {
                MotionDriver.PlayAnimation(ImageDirection.TopBottom, this);
            }
            ImageAnimation.Start(this);
            startImageLocation = endLocation;
            isDragging = false;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (startMouseLocation.X != e.X || startMouseLocation.Y != e.Y)
            {
                if (isDragging)
                {
                    Point newlocation = this.Location;
                    newlocation.X += e.X - startMouseLocation.X;
                    newlocation.Y += e.Y - startMouseLocation.Y;
                    this.Location = newlocation;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
            this.ImageAnimation.Dispose();
            this.MotionDriver.Dispose();
            this.MotionDriver = null;
            this.ImageAnimation = null;
        }

        public void Reset()
        {
            MotionDriver.PlayAnimation(ImageDirection.TopBottom, this);
            ImageAnimation.Stop();
            this.Location = new Point(354, 126);
        }
    }
}
