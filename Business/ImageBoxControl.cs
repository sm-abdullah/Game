
using System;
using System.Drawing;
using System.Windows.Forms;
using Entites;


/// <summary>
/// Business Implementation of Core Entity IImageBoxControl
/// Business should only depend on Core Business Entities
/// </summary>
namespace Game.Business
{
    public delegate void ImageReached(IImageBoxControl sender, ImageDirection direction);
    public delegate void DirectionChanged(object sender, ImageDirection direction);
    public class ImageBoxControl : PictureBox, IImageBoxControl
    {
        private Point _startMouseLocation = Point.Empty;
        private Point _startImageLocation = Point.Empty;
        private bool _isDragging = false;
        private bool _isDecesionMade;
        private IImageAnimation _imageAnimation;
        private IMotionDriver _motionDriver;
        public event ImageReached ImageReached;
        public event DirectionChanged Direction_Changed;
      

        /// <summary>
        /// Main constructor that requires Animation and modition driver
        /// </summary>
        /// <param name="motionDriver"></param>
        /// <param name="imageAnimation"></param>
        public ImageBoxControl(IMotionDriver motionDriver, IImageAnimation imageAnimation)
        {
            SetStyle(ControlStyles.Opaque, true);
            _imageAnimation = imageAnimation;
            _motionDriver = motionDriver;
            _motionDriver.ImageReached += MotionDriver_ImageReached;
            _isDecesionMade = false;
            this.Cursor = Cursors.Hand;

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
            _motionDriver.PlayAnimation(ImageDirection.TopBottom, this);
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            _startImageLocation = this.Location;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_isDecesionMade)
            {
                _motionDriver.Pause();
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Left)
                {
                    _isDragging = true;
                    _startMouseLocation = new Point(e.X, e.Y);
                    _startImageLocation = this.Location;
                }
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var endLocation = this.Location;
            var distance = Math.Sqrt((Math.Pow(_startImageLocation.X - endLocation.X, 2) + Math.Pow(_startImageLocation.Y - endLocation.Y, 2)));
            // if user pan more than 20 pix then change direction
            if (distance >= 20 && endLocation.X < _startImageLocation.X && endLocation.Y < _startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.LeftTop);
                _motionDriver.PlayAnimation(ImageDirection.LeftTop, this);


            }
            else if (distance >= 20 && endLocation.X > _startImageLocation.X && endLocation.Y < _startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.RightTop);
                _motionDriver.PlayAnimation(ImageDirection.RightTop, this);
            }
            else if (distance >= 20 && endLocation.X > _startImageLocation.X && endLocation.Y > _startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.RightBottom);
                _motionDriver.PlayAnimation(ImageDirection.RightBottom, this);

            }
            else if (distance >= 20 && endLocation.X < _startImageLocation.X && endLocation.Y > _startImageLocation.Y)
            {
                Direction_Changed?.Invoke(this, ImageDirection.LeftBottom);
                _motionDriver.PlayAnimation(ImageDirection.LeftBottom, this);
            }
            else
            {
                _motionDriver.PlayAnimation(ImageDirection.TopBottom, this);
            }
            _imageAnimation.Start(this);
            _startImageLocation = endLocation;
            _isDragging = false;
            _isDecesionMade = true;
            this.Cursor = Cursors.Arrow ;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_startMouseLocation.X != e.X || _startMouseLocation.Y != e.Y)
            {
                if (_isDragging)
                {
                    Point newlocation = this.Location;
                    newlocation.X += e.X - _startMouseLocation.X;
                    newlocation.Y += e.Y - _startMouseLocation.Y;
                    this.Location = newlocation;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._imageAnimation.Dispose();
            this._motionDriver.Dispose();
            this._motionDriver = null;
            this._imageAnimation = null;
        }

        public void Reset()
        {
            _isDecesionMade = false;
            this.Cursor = Cursors.Hand;
            _motionDriver.PlayAnimation(ImageDirection.TopBottom, this);
            _imageAnimation.Stop();
            this.Location = new Point(354, 126);
        }
    }
}
