using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game.ImageBox
{
    /// <summary>
    /// Interface of our main box control
    /// </summary>
    public interface IImageBoxControl
    {
        Image Image { get; set; }
        int Top { get; set; }
        int Left { get; set; }
        Point Location { get; set; }
        Control Parent { get; set; }
        int Height { get; set; }
        int Width { get; set; }
    }
}
