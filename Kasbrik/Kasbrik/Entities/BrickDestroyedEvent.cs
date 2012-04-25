using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLib.Events;

namespace Kasbrik.Entities
{
    public class BrickDestroyedEvent : IEvent
    {
        public Brick Brick { get; private set; }

        public BrickDestroyedEvent(Brick brick)
        {
            this.Brick = brick;
        }
    }
}
