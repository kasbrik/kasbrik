using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Events
{
    public interface ISubscription<TEvent> : IDisposable
        where TEvent : IEvent
    {
        Action<TEvent> Action { get; }
        IEventAggregator EventAggregator { get; }
    }
}
