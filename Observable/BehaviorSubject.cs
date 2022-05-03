using Yogi.Reactive.Interfaces;

namespace Yogi.Reactive
{
    public class BehaviorSubject<T> : Subject<T>
    {
        public static void Noop(ISubscriber<T> obs)
        {
        }

        public BehaviorSubject(T val) : base()
        {
            _val = val;
        }

        protected T _val;

        public new ISubscription Subscribe(ISubscriber<T> subscriber)
        {
            var sub = base.Subscribe(subscriber);

            subscriber.Next?.Invoke(_val);

            return sub;
        }

    }

}
