using Entites;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Business
{
    public interface IGameFlowManager
    {
        KeyValuePair<Image, Nationality>? GetNext();
        KeyValuePair<Image, Nationality>? GetMostRecent();
        void Reset();
    }
}
