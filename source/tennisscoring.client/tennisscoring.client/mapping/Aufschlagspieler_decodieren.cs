using System;

namespace tennisscoring.client
{
	public class Aufschlagspieler_decodieren
	{
		public void Process (char aufschlagspielerCode)
		{
			if (char.ToLower(aufschlagspielerCode) == 'a')
				Result(0);
			else
				Result(1);
		}
		
		public event Action<int> Result;
	}
}

