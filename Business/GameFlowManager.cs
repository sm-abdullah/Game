

using Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Business
{
    public class GameFlowManager : IGameFlowManager
    {
        private int _min = 0;
        private int _max = 9;
        private Dictionary<Image, Nationality> _images;
        private Random _random;
        private int _count;
        private int _last;
        private int _current;
        public GameFlowManager(IImageResources imageResources, int count)
        {
            _images = imageResources.GetImagesFromResources();
            _random = new Random();
            _count = count;
        }
        public void Reset()
        {
            _current = 0;
        }
        public KeyValuePair<Image, Nationality>? GetNext()
        {
            _current++;
            if (_current > _count) return null;
            int value = _random.Next(_min, _max);
            _last = value;
            return _images.ElementAt(value);
        }
        public KeyValuePair<Image, Nationality>? GetMostRecent() 
        {
            return _images.ElementAt(_last);
        }
    }
}
