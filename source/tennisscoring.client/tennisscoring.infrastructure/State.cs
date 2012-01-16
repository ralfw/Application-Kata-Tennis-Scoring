using System;

namespace tennisscoring.infrastructure
{
	public class State<T>
	{
		T _value;
	
		public State() {}
		public State(T initialValue) {_value = initialValue;}
		
		
		public void Write(T value, Action<T> continueWith)
		{
			_value = value;
			continueWith(_value);
		}
		
		public void Read(Action<T> continueWith)
		{
			continueWith(_value);
		}
		
		public void Read<S>(S data, Action<Tuple<S, T>> continueWith)
		{
			continueWith(new Tuple<S, T>(data, _value));
		}
	}
}

