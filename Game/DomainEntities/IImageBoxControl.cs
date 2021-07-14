using System.Drawing;
using System.Windows.Forms;
/// <summary>
/// By defination of clean architecture
/// Core business entites should be at the center
/// it should not depend on any thing.
/// </summary>
namespace Game.DomainEntities
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
