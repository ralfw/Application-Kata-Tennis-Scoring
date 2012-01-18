using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Setgewinn_feststellen
	{
		int _minGewinnspiele;
		bool _setMitTiebreakEntscheiden;
		
		int[] _spielgewinne = new int[2];
		
		
		public void Process(string spielgewinn)
		{
			_spielgewinne[int.Parse(spielgewinn.Split(':')[1])]++;
			
			Spielgewinn(new Tuple<int,int>(_spielgewinne[0], _spielgewinne[1]));
			
			if (_setMitTiebreakEntscheiden)
			{
				if (_spielgewinne[0]==_minGewinnspiele && _spielgewinne[1]==_minGewinnspiele)
					Normale_Spielzählung(false);
				else
				{
					if (_spielgewinne[0] > _minGewinnspiele || _spielgewinne[1] >= _minGewinnspiele)
						Gewinner_bestimmen();
				}
			}
			else
			{
				if ((_spielgewinne[0] >= _minGewinnspiele || _spielgewinne[1] >= _minGewinnspiele) &&
				    Math.Abs(_spielgewinne[0]-_spielgewinne[1]) >= 2)
					Gewinner_bestimmen();
			}
		}
		
		private void Gewinner_bestimmen()
		{
			if (_spielgewinne[0]>_spielgewinne[1])
				Setgewinn("Setgewinn:0");
			else
				Setgewinn("Setgewinn:1");
			
			Normale_Spielzählung(true);
			
			_spielgewinne = new int[2];
		}
		
		
		public void Config(Tuple<int, bool> config)
		{
			_minGewinnspiele = config.Item1;
			_setMitTiebreakEntscheiden = config.Item2;
		}
	
		
		public event Action<bool> Normale_Spielzählung;
		
		public event Action<Tuple<int,int>> Spielgewinn;
		public event Action<string> Setgewinn;
	}
}

