using System;

namespace Yogi.Reactive.Interfaces
{
    public interface ISubscriber<T>
    {
        Action<T>? Next { get; set; }
        Action<Exception>? Error { get; set; }
        Action? Complete { get; set; }
    }
}
