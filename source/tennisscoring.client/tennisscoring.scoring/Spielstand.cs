using System;
using System.Collections.Generic;

namespace tennisscoring.scoring
{
	public class Spielstand
	{
		public Spielpunkte SpielerAPunkte, SpielerBPunkte;
	}
	
	public enum Spielpunkte 
	{
		Love, 
		Fifteen, 
		Thirty, 
		Forty, 
		Deuce, 
		Advantage, 
		Winner
	}
}

