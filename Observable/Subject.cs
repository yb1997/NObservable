using Yogi.Reactive.Interfaces;

namespace Yogi.Reactive
{
    public class Subject<T> : Observable<T>
    {
        private static void Noop(ISubscriber<T> obs)
        {
        }

        public Subject() : base(Noop)
        {
        }

        public virtual void Next(T val)
        {
            internalSubscriber.Next?.Invoke(val);
        }

        public Observable<T> AsObservable()
        {
            return this;
        }
    }
}
