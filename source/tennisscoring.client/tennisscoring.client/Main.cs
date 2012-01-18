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
			var settings_erfragen = new Settings_erfragen();
			var aufnehmen = new view.Aufschlaggewinn_aufnehmen();
			var textdump = new view.Text_roh_ausgeben();
			
			var aufschlagspieler_decodieren = new Aufschlagspieler_decodieren();
			var schalter = new Spielzählungsschalter();
			var spielstand_hochzählen = new Spielstand_hochzählen();
			var tiebreak_hochzählen = new Tiebreak_hochzählen();
			var zwischenergebnis_formatieren = new mapping.Zwischenergebnis_formatieren();
			var endergebnis_formatieren = new mapping.Endergebnis_formatieren();
			
			var eventstore = new Eventstore();
			var spielgewinn_feststellen = new Spielgewinn_feststellen();
			var setgewinn_feststellen = new Setgewinn_feststellen();
			var matchgewinn_feststellen = new Matchgewinn_feststellen();
			
			// Bind
			settings_erfragen.ConfigSetgewinnfeststellung += setgewinn_feststellen.Config;
			settings_erfragen.ConfigMatchgewinnfeststellung += matchgewinn_feststellen.Config;
			
			aufnehmen.Result += aufschlagspieler_decodieren.Process;
			aufschlagspieler_decodieren.Result += schalter.Process;
			schalter.Normal_zählen += spielstand_hochzählen.Process;
			schalter.Tiebreak_zählen += tiebreak_hochzählen.Process;
			spielstand_hochzählen.Result += zwischenergebnis_formatieren.Spielstand_formatieren;
			spielstand_hochzählen.Result += _ => eventstore.Write(_, e => spielgewinn_feststellen.Process((string)e));
			tiebreak_hochzählen.Result += zwischenergebnis_formatieren.Spielstand_formatieren;
			tiebreak_hochzählen.Result += _ => eventstore.Write(_, e => spielgewinn_feststellen.Process((string)e));
			zwischenergebnis_formatieren.Result += textdump.Zwischenstand;
						
			spielgewinn_feststellen.Result += setgewinn_feststellen.Process;
			setgewinn_feststellen.Spielgewinn += zwischenergebnis_formatieren.Spielgewinn_formatieren;
			setgewinn_feststellen.Setgewinn += _ => eventstore.Write(_, e => matchgewinn_feststellen.Process((string)e));
			setgewinn_feststellen.Normale_Spielzählung += schalter.Switch;
			matchgewinn_feststellen.Setgewinn += zwischenergebnis_formatieren.Setgewinn_formatieren;
			matchgewinn_feststellen.Matchgewinn += () => eventstore.Read(endergebnis_formatieren.Process);
			endergebnis_formatieren.Result += textdump.Endstand;
			
			// Config
			settings_erfragen.Run();
			
			// Run
			aufnehmen.Run();
		}
	}
}
