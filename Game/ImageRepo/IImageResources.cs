using Game.DomainEntities;
using System.Collections.Generic;
using System.Drawing;


namespace Game.ImageRepo
{
    public interface IImageResources
    {
        Dictionary<Image, Nationality> GetImagesFromResources();
    }
}
