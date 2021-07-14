using Business;
using Entites;
using System.Collections.Generic;
using System.Drawing;
/// <summary>
/// External dependencies
/// 
/// </summary>
namespace External
{
    public class ImageResources : IImageResources
    {
        public Dictionary<Image, Nationality> GetImagesFromResources()
        {
            var images = new Dictionary<Image, Nationality>();
            images.Add(global::External.Properties.Resources.thai03, Nationality.Thai);
            images.Add(global::External.Properties.Resources.chines_01, Nationality.Chines);
            images.Add(global::External.Properties.Resources.Jap01, Nationality.Japnaies);
            images.Add(global::External.Properties.Resources.chines_02, Nationality.Chines);
            images.Add(global::External.Properties.Resources.thai02, Nationality.Thai);
            images.Add(global::External.Properties.Resources.jap02, Nationality.Japnaies);
            images.Add(global::External.Properties.Resources.kr_01, Nationality.Korean);
            images.Add(global::External.Properties.Resources.kr_02, Nationality.Korean);
            images.Add(global::External.Properties.Resources.thai01, Nationality.Thai);
            images.Add(global::External.Properties.Resources.chines_03, Nationality.Chines);
            return images;
        }
    }
}
