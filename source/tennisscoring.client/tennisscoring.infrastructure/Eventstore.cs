using System;
using System.Collections.Generic;
using System.Linq;

namespace tennisscoring.infrastructure
{
	public class Eventstore
	{
		List<object> _events = new List<object>();
		
		public void Write(object @event) { Write(@event, _=>{}); }
		public void Write(object @event, Action<object> continueWithEvent)
		{
			_events.Add(@event);
			continueWithEvent(@event);
		}
		
		public void Read(Action<IEnumerable<object>> continueWithEvents)
		{
			continueWithEvents(_events);
		}
		
		public void Read<T>(T data, Action<Tuple<T, IEnumerable<object>>> continueWithEvents)
		{
			continueWithEvents(new Tuple<T,IEnumerable<object>>(data, _events));
		}
	}
}

