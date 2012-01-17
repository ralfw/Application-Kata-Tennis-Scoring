using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Matchgewinn_feststellen
	{
		int[] _setgewinne = new int[2];
		
		
		public void Process(string setgewinn)
		{
			_setgewinne[int.Parse(setgewinn.Split(':')[1])]++;
			
			Setgewinn(new Tuple<int,int>(_setgewinne[0], _setgewinne[1]));
			
			if (_setgewinne[0]>=3 || _setgewinne[1]>=3)
			{
				if (_setgewinne[0]>_setgewinne[1])
					Matchgewinn("Matchgewinn:0");
				else
					Matchgewinn("Matchgewinn:1");
				
				_setgewinne = new int[2];
			}
		}
		
		
		public event Action<Tuple<int,int>> Setgewinn;
		public event Action<string> Matchgewinn;
	}
}

