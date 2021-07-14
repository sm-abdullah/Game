using Game.DomainEntities;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Game.Business
{
    public interface IGameFlowManager
    {
        Dictionary<Image, Nationality> GetNext();
    }
}
