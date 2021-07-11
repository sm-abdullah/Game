using Game.GameManger;
using System.Collections.Generic;
using System.Drawing;

namespace Game.ImageRepo
{
    public class ImageResources : IImageResources
    {
        public Dictionary<Image, Nationality> GetImagesFromResources()
        {
            var images = new Dictionary<Image, Nationality>();
            images.Add(global::Game.Properties.Resources.thai03, Nationality.Thai);
            images.Add(global::Game.Properties.Resources.chines_01, Nationality.Chines);
            images.Add(global::Game.Properties.Resources.Jap01, Nationality.Japnaies);
            images.Add(global::Game.Properties.Resources.chines_02, Nationality.Chines);
            images.Add(global::Game.Properties.Resources.thai02, Nationality.Thai);
            images.Add(global::Game.Properties.Resources.jap02, Nationality.Japnaies);
            images.Add(global::Game.Properties.Resources.kr_01, Nationality.Korean);
            images.Add(global::Game.Properties.Resources.kr_02, Nationality.Korean);
            images.Add(global::Game.Properties.Resources.thai01, Nationality.Thai);
            images.Add(global::Game.Properties.Resources.chines_03, Nationality.Chines);
            return images;
        }
    }
}
