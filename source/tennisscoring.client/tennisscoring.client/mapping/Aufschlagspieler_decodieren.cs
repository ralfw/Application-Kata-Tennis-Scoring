using System;

namespace tennisscoring.client
{
	public class Aufschlagspieler_decodieren
	{
		public void Process (char aufschlagspielerCode)
		{
			if (char.ToLower(aufschlagspielerCode) == 'a')
				Result(1);
			else
				Result(2);
		}
		
		public event Action<int> Result;
	}
}

