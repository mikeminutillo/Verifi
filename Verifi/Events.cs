using System;
using System.Collections.Generic;
using System.Linq;

namespace Verifi
{
    public interface IHandle<T>
    {
        void Handle(T message);
    }

    public static class Events
    {
        private static IList<object> _subscribers = new List<object>();
        private static object _lock = new object();

        class Disposable : IDisposable
        {
            public Action Action { get; set; }

            public void Dispose()
            {
                Action();
            }
        }

        public static IDisposable Add(object o)
        {
            lock (_lock)
                _subscribers.Add(o);
            return new Disposable
            {
                Action = () => { lock (_lock) _subscribers.Remove(o); }
            };
        }

        public static void Publish<T>(T message)
        {
            IHandle<T>[] handlers;
            lock (_lock) handlers = _subscribers.OfType<IHandle<T>>().ToArray();
            foreach (var handler in handlers)
                handler.Handle(message);
        }

    }
}
