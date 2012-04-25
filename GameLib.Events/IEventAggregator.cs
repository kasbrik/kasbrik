using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Events
{
    public interface IEventAggregator
    {
        ISubscription<TEvent> Subscribe<TEvent>(Action<TEvent> action)
            where TEvent : IEvent;
        void UnSubscribe<TEvent>(ISubscription<TEvent> subscription)
            where TEvent : IEvent;

        void Publish<TEvent>(TEvent evt)
            where TEvent : IEvent;
    }
}
