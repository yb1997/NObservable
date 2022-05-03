using Yogi.Reactive.Interfaces;

namespace Yogi.Reactive
{
    internal class Subscription<T> : ISubscription
    {
        private readonly Observable<T> _observable;
        private readonly ISubscriber<T> _subscriber;

        public Subscription(Observable<T> observable, ISubscriber<T> subscriber)
        {
            _observable = observable;
            _subscriber = subscriber;
        }

        public void Unsubscribe()
        {
            _observable.subscribers.Remove(_subscriber);
        }

    }
}
