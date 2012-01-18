using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Matchgewinn_feststellen
	{
		int _minSetgewinne;
		
		int[] _setgewinne = new int[2];
		
		
		public void Process(string setgewinn)
		{
			_setgewinne[int.Parse(setgewinn.Split(':')[1])]++;
			
			Setgewinn(new Tuple<int,int>(_setgewinne[0], _setgewinne[1]));
			
			if (_setgewinne[0]>=_minSetgewinne || _setgewinne[1]>=_minSetgewinne)
			{
				Matchgewinn();				
				_setgewinne = new int[2];
			}
		}
		
		
		public void Config(int minSetgewinne)
		{
			_minSetgewinne = minSetgewinne;
		}

		
		public event Action<Tuple<int,int>> Setgewinn;
		public event Action Matchgewinn;
	}
}

