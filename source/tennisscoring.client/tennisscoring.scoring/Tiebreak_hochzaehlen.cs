using System;

namespace tennisscoring.scoring
{
	public class Tiebreak_hochzählen
	{
		int[] _spielstand = new int[2];
		
		
		public void Process(int aufschlaggewinner)
		{
			_spielstand[aufschlaggewinner]++;
			var spielstand = string.Format("{0}:{1}", _spielstand[0], _spielstand[1]);
			
			if ((_spielstand[0] >= 7 || _spielstand[1] >= 7) &&
			    Math.Abs(_spielstand[0]-_spielstand[1]) >= 2)
			{
				if (_spielstand[0] > _spielstand[1])
					spielstand = string.Format("Winner:{0}", _spielstand[1]);
				else
					spielstand = string.Format("{0}:Winner", _spielstand[0]);
				
				_spielstand = new int[2];
			}
				
			Result(spielstand);
		}
		
		
		public event Action<string> Result;
	}
}

