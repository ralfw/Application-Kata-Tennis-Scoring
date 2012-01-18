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
			var spielstand_hochzählen = new Spielstand_hochzählen();
			var formatter = new mapping.Formatierer();
			
			var eventstore = new Eventstore();
			var spielgewinn_feststellen = new Spielgewinn_feststellen();
			var setgewinn_feststellen = new Setgewinn_feststellen();
			var matchgewinn_feststellen = new Matchgewinn_feststellen();
			
			// Bind
			erfassen.Result += aufschlagspieler_decodieren.Process;
			aufschlagspieler_decodieren.Result += spielstand_hochzählen.Process;
			spielstand_hochzählen.Result += formatter.Spielstand_formatieren;
			spielstand_hochzählen.Result += _ => eventstore.Write(_, e => spielgewinn_feststellen.Process((string)e));
			formatter.Result += textdump.Process;
						
			spielgewinn_feststellen.Result += _ => eventstore.Write(_, e => setgewinn_feststellen.Process((string)e));
			setgewinn_feststellen.Spielgewinn += formatter.Spielgewinn_formatieren;
			setgewinn_feststellen.Setgewinn += _ => eventstore.Write(_, e => matchgewinn_feststellen.Process((string)e));
			matchgewinn_feststellen.Setgewinn += formatter.Setgewinn_formatieren;
			matchgewinn_feststellen.Matchgewinn += () => eventstore.Read(formatter.Spielliste_formatieren);
			
			// Run
			erfassen.Run();
		}
	}
}
