using Game.DomainEntities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.Business
{
    /// <summary>
    /// Implemtation of Fadeout effect of an image
    /// </summary>
    public class ImageFadeout : IImageAnimation
    {
        private int Opacity = 0;
        private Timer timer;
        IImageBoxControl imageBoxControl;
        public ImageFadeout() 
        {

       
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 100;
        
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity < 120)
            {
                SetOpacity(imageBoxControl, Opacity);
                Opacity += 2;
                Console.WriteLine(Opacity);
            }
            else
            {
                Opacity = 0;
                timer.Stop();
            }

        }
        public  void Start(IImageBoxControl imageBoxControl)
        {
            this.imageBoxControl = imageBoxControl;
            timer.Start();
        }
   
        private void SetOpacity(IImageBoxControl imageBoxControl, int opacity)
        {
            if (imageBoxControl == null) return;
            Image image = imageBoxControl.Image;
            using (Graphics g = Graphics.FromImage(image))
            {
                Pen pen = new Pen(Color.FromArgb(opacity, 255, 255, 255), image.Width);
                g.DrawLine(pen, -1, -1, image.Width, image.Height);
                g.Save();
            }
            imageBoxControl.Image = image;

        }
        public void Stop() 
        {
            Opacity = 0;
            SetOpacity(imageBoxControl, 0);
            timer.Stop();
        }

        public void Dispose()
        {
            // un-sub event
            timer.Tick -= Timer_Tick;
            //stop timer
            timer.Stop();
            imageBoxControl = null;
            timer.Dispose();
        }
    }
}
