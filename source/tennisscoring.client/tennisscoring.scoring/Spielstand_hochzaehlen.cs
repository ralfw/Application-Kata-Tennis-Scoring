using System;
using System.Collections.Generic;
using System.Linq;


namespace tennisscoring.scoring
{
	public class Spielstand_hochzählen
	{
		 readonly string[][] _zählbaum = new[]{
			new[]{"Love:Love",		"Fifteen:Love",		"Love:Fifteen"},
			new[]{"Fifteen:Love", 	"Thirty:Love",		"Fifteen:Fifteen"},
			new[]{"Thirty:Love",	"Forty:Love",		"Thirty:Fifteen"},
			new[]{"Forty:Love",		"Winner:Love",		"Forty:Fifteen"},
			new[]{"Love:Fifteen",	"Fifteen:Fifteen",	"Love:Thirty"},
			new[]{"Love:Thirty",	"Fifteen:Thirty",	"Love:Forty"},
			new[]{"Love:Forty",		"Fifteen:Forty",	"Love:Winner"},
			new[]{"Fifteen:Fifteen","Thirty:Fifteen",	"Fifteen:Thirty"},
			new[]{"Thirty:Fifteen",	"Forty:Fifteen",	"Thirty:Thirty"},
			new[]{"Fifteen:Thirty",	"Thirty:Thirty",	"Fifteen:Forty"},
			new[]{"Forty:Fifteen",	"Winner:Fifteen",	"Forty:Thirty"},
			new[]{"Thirty:Thirty",	"Forty:Thirty",		"Thirty:Forty"},
			new[]{"Fifteen:Forty",	"Thirty:Forty",		"Fifteen:Winner"},
			new[]{"Forty:Thirty",	"Winner:Thirty",	"Deuce:Deuce"},
			new[]{"Thirty:Forty",	"Deuce:Deuce",		"Thirty:Winner"},
			new[]{"Deuce:Deuce",	"Advantage:Deuce",	"Deuce:Advantage"},
			new[]{"Advantage:Deuce","Winner:Deuce",		"Deuce:Deuce"},
			new[]{"Deuce:Advantage","Deuce:Deuce",		"Deuce:Winner"}
		};
		
		public void Process(Tuple<int, Spielstand> input)
		{
			var aufschlaggewinner = input.Item1;
			var spielstand = input.Item2;
			
			var zählstand = _zählbaum.Where(z => z[0] == spielstand.Punkte).FirstOrDefault();
			if (zählstand == null) 
				throw new ArgumentException(string.Format("Keine Spielstand für {0} wenn Spieler {1} gewinnt.", 
				                                          spielstand.Punkte, aufschlaggewinner));
			spielstand.Punkte = zählstand[aufschlaggewinner+1];
			
			Result(spielstand);
		}
		
		public event Action<Spielstand> Result;
	}
}

