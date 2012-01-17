using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Setgewinn_feststellen
	{
		int[] _spielgewinne = new int[2];
		
		
		public void Process(string spielgewinn)
		{
			_spielgewinne[int.Parse(spielgewinn.Split(':')[1])]++;
			
			Spielgewinn(new Tuple<int,int>(_spielgewinne[0], _spielgewinne[1]));
			
			if ((_spielgewinne[0] >= 6 || _spielgewinne[1] >= 6) &&
			    Math.Abs(_spielgewinne[0]-_spielgewinne[1]) >= 2)
			{
				if (_spielgewinne[0]>_spielgewinne[1])
					Setgewinn("Setgewinn:0");
				else
					Setgewinn("Setgewinn:1");
				
				_spielgewinne = new int[2];
			}
		}
	
		
		public event Action<Tuple<int,int>> Spielgewinn;
		public event Action<string> Setgewinn;
	}
}

