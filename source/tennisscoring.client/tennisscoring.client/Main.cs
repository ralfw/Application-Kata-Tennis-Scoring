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
			var spielstand = new State<Spielstand>();
			
			var erfassen = new Aufschlag_erfassen();
			var textdump = new Text_roh_ausgeben();
			
			var spielstand_hochzählen = new Spielstand_hochzählen();
			var spielstand_formatieren = new Spielstand_formatieren();
			
			// Bind
			erfassen.Result += _ => spielstand.Read(_, spielstand_hochzählen.Process);
			spielstand_hochzählen.Result += _ => spielstand.Write(_, spielstand_formatieren.Process);
			spielstand_formatieren.Result += textdump.Process;
			
			// Config
			spielstand.Write(new Spielstand(), _ => {});
			
			// Run
			erfassen.Run();
		}
	}
	
	
	class Aufschlag_erfassen
	{
		public void Run()
		{
			while(true)
			{
				Console.Write("Aufschlaggewinner (a/b): ");
				string input = Console.ReadLine().ToLower();
				if (input.Length > 0 && "ab".IndexOf(input[0]) >= 0)
					Result(input[0]);
			}	
		}
		
		public event Action<char> Result;
	}
	
	
	class Text_roh_ausgeben
	{
		public void Process(IEnumerable<string> daten)
		{
			daten.ToList().ForEach(d => Console.WriteLine(d));
		}
	}
	
	
	class Spielstand_formatieren
	{
		public void Process(Spielstand spielstand)
		{
			Result(new[]{string.Format("  {0} : {1}", spielstand.SpielerAPunkte, spielstand.SpielerBPunkte)});
		}
		
		public event Action<IEnumerable<string>> Result;
	}
}
