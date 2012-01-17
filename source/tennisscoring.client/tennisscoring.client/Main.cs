using System;
using System.Collections.Generic;
using System.Linq;

using tennisscoring.scoring;
using tennisscoring.infrastructure;

namespace tennisscoring.client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Tennis Scoring 1.0\n");
			
			// Build
			var erfassen = new view.Aufschlag_erfassen();
			var textdump = new view.Text_roh_ausgeben();
			
			var aufschlagspieler_decodieren = new Aufschlagspieler_decodieren();
			var spielstand = new Spielstand_hochzählen();
			var spielstand_formatieren = new mapping.Spielstand_formatieren();
			var match_formatieren = new Matchstand_formatieren();
			
			var spielgewinn_feststellen = new Spielgewinn_feststellen();
			var setgewinn_feststellen = new Setgewinn_feststellen();
			var matchgewinn_feststellen = new Matchgewinn_feststellen();
			
			// Bind
			erfassen.Result += aufschlagspieler_decodieren.Process;
			aufschlagspieler_decodieren.Result += spielstand.Process;
			spielstand.Result += spielstand_formatieren.Process;
			spielstand_formatieren.Result += textdump.Process;
						
			// Run
			erfassen.Run();
		}
	}
}
