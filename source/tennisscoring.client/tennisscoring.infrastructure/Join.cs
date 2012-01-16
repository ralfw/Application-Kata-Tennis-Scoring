using System;

namespace tennisscoring.infrastructure
{
	public class ManualResetJoin<T0, T1>
	{
		T0 _value0;
		bool _assigned0;
		
		T1 _value1;
		bool _assigned1;
		
		
		public void Process0(T0 input)
		{
			_value0 = input;
			_assigned0 = true;
			if (_assigned1) Fire();
		}
		
		public void Process1(T1 input)
		{
			_value1 = input;
			_assigned1 = true;
			if (_assigned0) Fire();
		}
		
		
		public void Reset()
		{
			_assigned0 = false;
			_assigned1 = false;
		}
		
		
		void Fire()
		{
			var v0 = _value0;
			var v1 = _value1;
			Result(new Tuple<T0, T1>(v0, v1));
		}
		
		
		public event Action<Tuple<T0, T1>> Result;
	}
}

