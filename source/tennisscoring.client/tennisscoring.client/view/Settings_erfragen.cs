using System;

namespace tennisscoring.client
{
	public class Settings_erfragen
	{
		public void Run()
		{
			Console.Write("Spiele zu gewinnen pro Satz: ");
			var minGewinnspiele = int.Parse(Console.ReadLine());
			
			Console.Write("Sätze zu gewinnen pro Match: ");
			var minSetgewinne = int.Parse(Console.ReadLine());
			
			Console.Write("Satzgewinn bei Bedarf per Tie-Break (j/n): ");
			var setMitTiebreakEntscheiden = Console.ReadLine().ToLower() == "j" ? true : false;
			
			Console.WriteLine();
			
			ConfigSetgewinnfeststellung(new Tuple<int,bool>(minGewinnspiele, setMitTiebreakEntscheiden));
			ConfigMatchgewinnfeststellung(minSetgewinne);
		}
		
		public event Action<Tuple<int,bool>> ConfigSetgewinnfeststellung;
		public event Action<int> ConfigMatchgewinnfeststellung;
	}
}

