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
			var spielstand = new Spielstand_aktualisieren();
			var spielstand_formatieren = new mapping.Spielstand_formatieren();
			
			// Bind
			erfassen.Result += aufschlagspieler_decodieren.Process;
			aufschlagspieler_decodieren.Result += spielstand.Process;
			spielstand.Result += spielstand_formatieren.Process;
			spielstand_formatieren.Result += textdump.Process;
			
			// Config
			spielstand.Initialisieren();
			
			// Run
			erfassen.Run();
		}
	}
}
