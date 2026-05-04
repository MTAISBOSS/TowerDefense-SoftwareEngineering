using System;
using System.Collections.Generic;

namespace EventSystem
{
    public class EventBus<T> where T: IEvent
    {
        private static readonly HashSet<IEventBinding<T>> Bindings = new HashSet<IEventBinding<T>>();

        public static void Register(EventBinding<T> binding) => Bindings.Add(binding);
        public static void Unregister(EventBinding<T> binding) => Bindings.Remove(binding);

        public static void Raise(T @event)
        {
            foreach (var binding in Bindings)
            {
                binding.OnEventNoArgs.Invoke();
                binding.OnEvent.Invoke(@event);
            }
        }
    }

    public interface IEvent
    {
    }
}