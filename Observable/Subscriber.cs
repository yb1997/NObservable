using System;
using Yogi.Reactive.Interfaces;

namespace Yogi.Reactive
{
    public class Subscriber<T> : ISubscriber<T>
    {
        public Action<T>? Next { get; set; }
        public Action<Exception>? Error { get; set; }
        public Action? Complete { get; set; }
    }
}
