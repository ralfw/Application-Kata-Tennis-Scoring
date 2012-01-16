using System;

namespace tennisscoring.scoring
{
	public class Spielstand_hochzählen
	{
		public void Process(Tuple<char, Spielstand> input)
		{
			var aufschlaggewinner = input.Item1;
			var spielstand = input.Item2;
			
			if (DateTime.Now.Second % 2 == 0)
				spielstand.SpielerAPunkte = Spielpunkte.Forty;
			else
				spielstand.SpielerAPunkte = Spielpunkte.Fifteen;
			
			if (DateTime.Now.Second % 3 == 0)
				spielstand.SpielerBPunkte = Spielpunkte.Thirty;
			else
				spielstand.SpielerBPunkte = Spielpunkte.Deuce;
			
			Result(spielstand);
		}
		
		public event Action<Spielstand> Result;
	}
}

