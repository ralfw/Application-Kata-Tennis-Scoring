using System;

namespace tennisscoring.scoring
{
	public class Spielzählungsschalter
	{
		bool _normalZählen = true;
		
		
		public void Process(int aufschlaggewinner)
		{
			if (_normalZählen)
				Normal_zählen(aufschlaggewinner);
			else
				Tiebreak_zählen(aufschlaggewinner);
		}
		
		
		public void Switch(bool normalZählen)
		{
			_normalZählen = normalZählen;
		}
		
		
		public event Action<int> Normal_zählen;
		public event Action<int> Tiebreak_zählen;
	}
}

