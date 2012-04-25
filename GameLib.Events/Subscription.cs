using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Events
{
    public class Subscription<TEvent> : ISubscription<TEvent>
        where TEvent : IEvent
    {
        public Subscription(Action<TEvent> action, IEventAggregator eventAggregator)
        {
            if (action == null) throw new ArgumentNullException("action");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");

            Action = action;
            EventAggregator = eventAggregator;
        }

        #region ISubscription<TEvent> Members

        public Action<TEvent> Action { get; private set; }
        public IEventAggregator EventAggregator { get; private set; }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                EventAggregator.UnSubscribe(this);
        }

        #endregion
    }
}
