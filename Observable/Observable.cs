using System;
using System.Collections.Generic;
using Yogi.Reactive.Interfaces;

namespace Yogi.Reactive
{
    public class Observable<T>
    {
        public List<ISubscriber<T>> subscribers = new List<ISubscriber<T>>();
        protected bool isComplete = false;
        protected ISubscriber<T> internalSubscriber;

        public Observable(Action<ISubscriber<T>> observer)
        {
            internalSubscriber = new Subscriber<T>();
            internalSubscriber.Next = (val) =>
            {
                subscribers.ForEach(s =>
                {
                    s.Next?.Invoke(val);
                });
            };
            internalSubscriber.Error = (ex) =>
            {
                subscribers.ForEach(s =>
                {
                    s.Error?.Invoke(ex);
                    s.Complete?.Invoke();
                });
                isComplete = true;
                subscribers.RemoveAll(_ => true);
            };
            internalSubscriber.Complete = () =>
            {
                subscribers.ForEach(s =>
                {
                    s.Complete?.Invoke();
                });
                isComplete = true;
                subscribers.RemoveAll(_ => true);
            };
            observer(internalSubscriber);
        }

        public virtual ISubscription Subscribe(ISubscriber<T> subscriber)
        {
            if (isComplete) throw new InvalidOperationException("Observable is already complete");

            subscribers.Add(subscriber);

            return new Subscription<T>(this, subscriber);
        }
    }
}
