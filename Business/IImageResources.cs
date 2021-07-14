using Entites;
using System.Collections.Generic;
using System.Drawing;
namespace Business
{
    public interface IImageResources
    {
        Dictionary<Image, Nationality> GetImagesFromResources();
    }
}
