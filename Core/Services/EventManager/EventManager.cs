using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Services.EventManager
{
	public static class EventManager
	{
		private static readonly Dictionary<Type, IList> _eventToHandlersMap = new Dictionary<Type, IList>();

		public static void Subscribe<T>(IMessageHandler<T> handler)
		{
			var eventType = typeof (T);

			if (_eventToHandlersMap.ContainsKey(eventType))
			{
				_eventToHandlersMap[eventType].Add(handler);
			}
			else
			{
				_eventToHandlersMap.Add(eventType, new List<IMessageHandler<T>>() {handler});
			}
		}

		public static void Usubscribe<T>(IMessageHandler<T> handler)
		{
			var eventType = typeof (T);
			if (_eventToHandlersMap.ContainsKey(eventType))
			{
				_eventToHandlersMap[eventType].Remove(handler);
			}
		}

		public static void Raise<T>(T evnt)
		{
			var eventType = typeof (T);

			if (_eventToHandlersMap.ContainsKey(eventType))
			{
				return;
			}

			var handlers = _eventToHandlersMap[eventType];

			foreach (var handler in handlers)
			{
				(handler as IMessageHandler<T>)?.Handle(evnt);
			}
		}
	}
}