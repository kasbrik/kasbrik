using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace GameLib.Events
{
    public class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, IList> subscriptions;

        public EventAggregator()
        {
            this.subscriptions = new Dictionary<Type, IList>();
        }

        #region IEventAggregator Members

        public ISubscription<TEvent> Subscribe<TEvent>(Action<TEvent> action) where TEvent : IEvent
        {
            if (action == null) throw new ArgumentNullException("action");

            Type eventType = typeof(TEvent);
            var subscription = new Subscription<TEvent>(action, this);

            if (this.subscriptions.ContainsKey(eventType))
                this.subscriptions[eventType].Add(subscription);
            else
                this.subscriptions.Add(eventType, new List<ISubscription<TEvent>> { subscription });

            return subscription;
        }

        public void UnSubscribe<TEvent>(ISubscription<TEvent> subscription) where TEvent : IEvent
        {
            if (subscription == null) throw new ArgumentNullException("subscription");

            Type eventType = typeof(TEvent);

            if (this.subscriptions.ContainsKey(eventType))
                this.subscriptions[eventType].Remove(subscription);
        }

        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
            if (evt == null) throw new ArgumentNullException("evt");

            Type eventType = typeof(TEvent);

            if (this.subscriptions.ContainsKey(eventType))
            {
                var subscriptionList = new List<ISubscription<TEvent>>(
                    this.subscriptions[eventType].Cast<ISubscription<TEvent>>());

                foreach (var subscription in subscriptionList)
                {
                    subscription.Action(evt);
                }
            }
        }

        #endregion
    }
}
