using System;

namespace tennisscoring.client.view
{
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
}

